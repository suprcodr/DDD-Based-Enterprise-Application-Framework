﻿using System;
using System.Collections;
using Infrastructure;

namespace ApplicationAndInfrastructureServices.BatchProcessing
{
    public class BatchProcessingExecutor : DisposableClass, IBatchProcessingExecutor
    {
        IBatchSeedSelector _batchSeedSelector;
        IBatchCommandProcesor _batchCommandProcesor;

        public BatchProcessingExecutor(IBatchSeedSelector batchSeedSelector,IBatchCommandProcesor batchCommandProcesor)
        {
            _batchSeedSelector = batchSeedSelector;
            _batchCommandProcesor = batchCommandProcesor;
        }

        public bool ExecuteBatchProcess()
        {
            Boolean result = false;
            _batchSeedSelector.Reset();
            do
            {
                _batchSeedSelector.Execute();
                if (_batchSeedSelector.Current.IsNotNull())
                {
                    IEnumerable[] batchSelectorEnumerables = _batchSeedSelector.Current as IEnumerable[];
                    if (batchSelectorEnumerables.Length > 0)
                    {
                        /// Process the batchSelectorEnumerables
                        result = _batchCommandProcesor.Execute(batchSelectorEnumerables);
                    }
                }
                if(!result)
                {
                    break;
                }
            }
            while (_batchSeedSelector.MoveNext());
            return result;
        }

        protected override void FreeManagedResources()
        {
            _batchSeedSelector.Dispose();
            _batchCommandProcesor.Dispose();
        }
    }
}
