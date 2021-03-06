﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Base.Aggregates;
using Infrastructure;
using Infrastructure.Extensions;
using Infrastructure.Logging;
using Infrastructure.Logging.Loggers;
using Infrastructure.Utilities;
using Repository.Base;

namespace ApplicationAndInfrastructureServices.BatchProcessing
{
    public abstract class BaseBatchSeedSelector<TEntity,TId> : DisposableClass, IBatchSeedSelector
        where TEntity : IQueryableAggregateRoot
        where TId : struct,IComparable<TId>
    {
        private readonly IQueryableRepository<TEntity> _seedQueryableRepository;
        private TId _currentBatchStartPosition;
        private readonly int _batchSize;
        private IEnumerable<TEntity> _currentBatch;
        private readonly ILogger _logger;
        private IEnumerable[] _allBatchEnumerablesIncludingCurrentSeedBatch;
        private TId _maxEntityPropertyRangeFilterIdentifier;

        public BaseBatchSeedSelector(IQueryableRepository<TEntity> seedQueryableRepository, int batchSize,ILogger logger)
        {
            ContractUtility.Requires<ArgumentNullException>(seedQueryableRepository.IsNotNull(), "seedQueryableRepository cannot be null");
            ContractUtility.Requires<ArgumentOutOfRangeException>(batchSize > 0, "batchSize should be greater than 0");
            ContractUtility.Requires<ArgumentNullException>(logger.IsNotNull(), "logger cannot be null");
            _seedQueryableRepository = seedQueryableRepository;
            _batchSize = batchSize;
            _logger = logger ?? LoggerFactory.GetLogger(LoggerType.Default);
        }

        public virtual void Execute()
        {
            CheckForObjectAlreadyDisposedOrNot(typeof(BaseBatchSeedSelector<TEntity, TId>).FullName);
            TId currentBatchEndPosition = _currentBatchStartPosition.Add(_batchSize.ConvertToType<TId>());
            _currentBatch = BatchQueryable.Between(x => EntityPropertyRangeFilterIdentifier(x), _currentBatchStartPosition,currentBatchEndPosition).ToList();

            if (_currentBatch.IsNotEmpty())
            {
                TId actualBatchEndPosition = _currentBatch.Max(x => EntityPropertyRangeFilterIdentifier(x));
                _logger.LogMessage("Actual number of records fetched from the seed data source for the start position of " + _currentBatchStartPosition + " and end position of " + currentBatchEndPosition + "(actualBatchEndPosition = " + actualBatchEndPosition + ") is : " + _currentBatch.Count());
            }
            ProcessCurrentBatchFurther(_currentBatch);
            _allBatchEnumerablesIncludingCurrentSeedBatch = GetAllBatchesBasedOnCurrentSeedBatch(_currentBatch);
        }

        public object Current
        {
            get
            {
                CheckForObjectAlreadyDisposedOrNot(typeof(BaseBatchSeedSelector<TEntity, TId>).FullName);
                return _allBatchEnumerablesIncludingCurrentSeedBatch;
            }
        }

        public bool MoveNext()
        {
            CheckForObjectAlreadyDisposedOrNot(typeof(BaseBatchSeedSelector<TEntity, TId>).FullName);
            if (_currentBatch.IsNullOrEmpty())
            {
                return false;
            }
            _currentBatchStartPosition = _currentBatch.Max(x => EntityPropertyRangeFilterIdentifier(x));
            _currentBatchStartPosition = _currentBatchStartPosition.Add(ValueToIncrementByToGoToNextBatch);
            if(_maxEntityPropertyRangeFilterIdentifier.IsEqualTo(default(TId)))
            {
                _maxEntityPropertyRangeFilterIdentifier = _seedQueryableRepository.Max(x => EntityPropertyRangeFilterIdentifier(x));
            }
            return _currentBatchStartPosition.IsLesserThanOrEqualTo(_maxEntityPropertyRangeFilterIdentifier);
        }

        public void Reset()
        {
            _currentBatchStartPosition = _seedQueryableRepository.Min(x => EntityPropertyRangeFilterIdentifier(x));
        }

        protected virtual IQueryable<TEntity> BatchQueryable
        {
            get { return _seedQueryableRepository; }
        }

        protected virtual TId ValueToIncrementByToGoToNextBatch
        {
            get { return 1.ConvertToType<TId>(); }
        }

        /// <summary>
        /// The property/column based on which dataset range filtering is to be done
        /// </summary>
        protected abstract Func<TEntity,TId> EntityPropertyRangeFilterIdentifier { get; }

        protected virtual void ProcessCurrentBatchFurther(IEnumerable currentBatch) { }

        protected virtual IEnumerable[] GetAllBatchesBasedOnCurrentSeedBatch(IEnumerable currentSeedBatch)
        {
            IEnumerable[] batchEnumerables = new IEnumerable[1];
            batchEnumerables[0] = currentSeedBatch;
            return batchEnumerables;
        }

        protected override void FreeManagedResources()
        {
            _seedQueryableRepository.Dispose();
        }
    }
}
