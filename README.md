# Domain Driven Design Based Enterprise Application Framework 

An opinionated Enterprise Application Framework based on different Patterns, Principles and Practices of Domain Driven Design. Although not all tactical and strategic Patterns, Principles and Practices of DDD are in place but the most important ones (the ones that are used almost in any Enterprise app) are in place.    
This framework is helpful in scenarios wherein one needs to interact with different Integration technologies using different .NET based access technologies (can be DBs, SOAP or RESTFUL Web Services or MQs or File System or an LDAP or any other imaginable data source).Another possible scenario can be in a CQRS (Command Query Responsibility Segregation) environment wherein the commands are processed in an RDBMS like SQL Server whereas the queries are executed to fetch data from NOSQL Dbs. Also, once this framework is completed and if someone uses this framework, at least for the development of a SPA based Web Application or Website or a Mobile Web application, ideally he/or she should need to work only on Domain Modelling(i.e. mainly Domain, Domain Services and Application Services) and UI stuffs(there might be some requirement for extending some extensibility points which are already provided out of the box or creating new extensibility points all-together or some other configuration stuff changes required like DI container specific stuffs or ORM configurations if RDBMS is used etc.).That doesn't mean that all these can be applied only for Web apps or Websites or Mobile Web Application only but in-fact, parts of this framework can be applied to other types of applications as well e.g. Business Process Management and Integration projects as well.     
DDD is more about domain modelling for complex domains using concepts of Entities, Value Objects, and Aggregates etc. and separating out your Business functionalities from your technical functionalities. Although this framework provides(or will provide) most of the technical functionalities(out of the box, including the source code) used in an Enterprise app and some base level classes for dealing with Entities, Value Objects, Aggregates etc. but it's not necessary that one is going to need every bit of it. So use this framework (or may be just parts of the framework) diligently after analyzing the requirements for your app meticulously.      
Implementation Overview-> Here the CommandRepository(for persisting data) and QueryableRepository(for querying data) are in-memory representation of some external source - mainly DBs(but can be extended to Web Services or MQ interactions as well or any other imaginable data source for that matter). The CommandRepository class needs instances of concrete implementation of BaseUnitOfWork and ICommand which can be injected using some DI Framework like Unity.      
UnitOfWork (implements IUnitOfWork members) - De-couples the logic to do atomic transactions across Dbs(can be extended to use Web Services/MQs or some other data source as well to be part of the Transaction) using different DB access technologies(again can be extended to use Web Service/MQs or any other data source). UnitOfWork based transactions can be applied at the API or Domain Services or Repository layer.        
ICommand & IQuery- Provides contracts to deal with different DB technologies viz. ADO.NET, Enterprise Library or ORMs like Entity FrameWork Code First etc. and different DBs (current implementation supports mainly SQL Server - but as mentioned earlier also, can be extended to support other DB types as well).    

N.B.-> If one wants to think of any imaginable data source as Repository then at least for the query side it's better to have a IQueryable provider for the same (at least to use this framework seamlessly). For an exhaustive list of open source IQueryable providers, one can visit [Linq to Everything](https://blogs.msdn.microsoft.com/charlie/2008/02/28/link-to-everything-a-list-of-linq-providers/) (well, it's almost EVERYTHING).If some imaginable data source is not mentioned in the afore-mentioned list then one can build his/her own IQueryable provider and hopefully the articles viz. [LINQ: Building an IQueryable provider series](https://blogs.msdn.microsoft.com/mattwar/2008/11/18/linq-building-an-iqueryable-provider-series/), [Building Custom LINQ Enabled Data Providers](https://blogs.msdn.microsoft.com/tommer/2007/04/20/building-custom-linq-enabled-data-providers-using-iqueryablet/), [Creating LINQToTwitter library using LinqExtender](http://weblogs.asp.net/mehfuzh/creating-linqtotwitter-library-using-linqextender) and [Writing A Custom LINQ Provider With Re-linq](https://blog.fairwaytech.com/2013/03/writing-a-custom-linq-provider-with-re-linq) can be helpful in doing the same. And if anyone builds any LINQ to Something (or "Anything") provider, then please don't forget to share it with the world. Some other intriguing reads on LINQ are [Analytic Functions using LINQ](https://github.com/linq2db/linq2db/wiki/Window-Functions-(Analytic-Functions)), [SqlDependency Based Caching of LINQ Queries](https://www.codeproject.com/Articles/141589/SqlDependency-based-caching-of-LINQ-Queries), [Dynamically evaluated SQL LINQ queries](https://www.codeproject.com/Articles/43678/Dynamically-evaluated-SQL-LINQ-queries) and [Building LINQ Queries at Runtime in C#](http://tomasp.net/blog/dynamic-linq-queries.aspx/).     

Pending Tasks ->       
• Incorporation of some tactical DDD stuffs (mainly the common framework elements).       
• Trying exploring and incorporating Dapper(a Micro-ORM - Micro ORMs may not provide you some functionalities like UnitOfWork out of the   box like that of an ORM but performance wise they are way better compared to ORMs), Event Stores and Grid Based Storage.
• Incorporation of some Restful stuffs which are commonly used in most Enterprise Apps.      
• Whatever done till now is all Orchestrations rather than Event Driven Choreographies. Even the async await based request reply           mechanisms are also actually Orchestrations. True Fire and Forget Event Driven Choreographies (may be with some nominal                acknowledgement   sent to the requester) following Eventually Consistent approach WILL ALSO BE TRIED, at the Web API Layer using       "Event Driven Rest"     and at the Business Layer using [Zero MQ](http://zeromq.org/).[Zero  MQ](http://zeromq.org/) was designed       from the ground up, keeping   in mind stock trading apps wherein very high throughput and very low latency are required, as discussed   [here](http://aosabook.org/en/zeromq.html).                  
  N.B. -> One can refer the paper - [Your Coffee Shop Doesn't use 2 phase commit](http://www.enterpriseintegrationpatterns.com/docs/IEEE_Software_Design_2PC.pdf) (written by the Integration genius - Gregor  Hohpe, co- author of the Integration Bible viz. [Enterprise Integration Patterns](http://www.enterpriseintegrationpatterns.com/)) to see how apps can be implemented without using Transactional Consistency.        
• Testing BulkOperations using SQL Express Edition.     
• Fixing WCF related Unit Test Case(s).      
• Redesign Caching stuffs to support in-memory caching or some scalable option like Windows AppFabric or Redis(a scalable NOSQL option). Ideally, should be designed in a pluggable way to support any cool Caching mechanism coming in future as well. Also should use some AOP or attribute (annotation) based approach to apply Caching or invalidating the Cache else it becomes very hectic to apply these cross cutting concerns everywhere within a large application.       
• Exploring Single Page Applications and building a Fluent UI Framework using which the UI layout (HTML + CSS) and UI Behaviors (using JavaScript) can be coded in a fluent way using JavaScript. IF POSSIBLE, will try to have plugin features wherein SPA Frameworks like Angular or React can be plugged in as and when required. Will also try to incorporate Offline-First capabilities. All these probably will have a GitHub Project of its own and that will be used in this project.This is going to take quite some time since lots of exploration needs to be done in this area.     
• Ultimately building a SAAS Framework based on all the above stuffs.      
• Fixing or suppressing the Warnings generated by MS Code Analysis Tool (currently, Code Analysis Settings is set to "Microsoft Basic Design Guidelines").     
• Also need to run the Code Metrics to check everything is as per standards.       
         
References(not that everything mentioned below is referred to build this framework, but atleast some bits of each of these awesome resources mentioned below have been referred or will be referred) -       
1) [Patterns, Principles and Practices of Domain Driven Design](http://www.wrox.com/WileyCDA/WroxTitle/Patterns-Principles-and-Practices-of-Domain-Driven-Design.productCd-1118714709.html)      
2) [JavaScript Domain Driven Design](https://www.packtpub.com/web-development/javascript-domain-driven-design)     
3) [Coding for Domain Driven Design](https://msdn.microsoft.com/en-us/magazine/dn342868.aspx)     
4) [Domain Driven Design Wiki](https://en.wikipedia.org/wiki/Domain-driven_design)      
5) Some very good samples to look out for DDD are [Domain-Driven Design Using a Trading Application Example](https://archfirst.org/bullsfirst/), [DDD E-Commerce Sample](https://github.com/zkavtaskin/Domain-Driven-Design-Example), [Domain Driven Design Using SpringTrader](https://blog.pivotal.io/pivotal/products/springone-video-domain-driven-design-using-springtrader), [Click's Hexagonal Domain Driven Architecture](https://github.com/ClickTravel/Cheddar) and [Reactive DDD/CQRS using Akka](https://www.infoq.com/news/2014/06/ddd-cqrs-akka-application). Some other good open source DDD apps are like- [I](http://stackoverflow.com/questions/152120/are-there-any-open-source-projects-using-ddd-domain-driven-design) and [II](http://stackoverflow.com/questions/540130/good-domain-driven-design-samples).       
6) [CQRS Wiki](https://en.wikipedia.org/wiki/Command%E2%80%93query_separation#Command_Query_Responsibility_Segregation), [How Eventuate Works](http://eventuate.io/howeventuateworks.html), [Rinat Abdullin On CQRS](https://abdullin.com/tags/cqrs/), [CQRS Myths](https://lostechies.com/jimmybogard/2012/08/22/busting-some-cqrs-myths/), [When To Avoid CQRS](http://udidahan.com/2011/04/22/when-to-avoid-cqrs/) and [CQRS Examples](http://stackoverflow.com/questions/5043513/cqrs-examples-and-screencasts)         
7) [Building MicroServices](http://shop.oreilly.com/product/0636920033158.do) and [MicroServices in .NET](https://www.manning.com/books/microservices-in-net)(mainly the source code)      
8) [Almost Anything and Everything about ASP.NET Web API](http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api)(including [ASP.NET WEB API 2: HTTP MESSAGE LIFECYLE](http://www.asp.net/media/4071077/aspnet-web-api-poster.pdf) and one can go through [ASP.NET MVC Page Life Cycle](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/lifecycle-of-an-aspnet-mvc-5-application), [ASP.NET MVC Pipeline And Extensibility](https://www.infoq.com/news/2011/09/aspnet-extensibility) as well to understand the ASP.NET Page Lifecycle and ASP.NET MVC Extensibility) and [Designing Evolvable Web APIs with ASP.NET](http://chimera.labs.oreilly.com/books/1234000001708). To learn the basics of ASP.NET MVC one can go through [ASP.NET MVC Interview Questions](https://www.codeproject.com/Articles/556995/ASP-NET-MVC-interview-questions-with-answers)     
9) [WCF Basics](https://www.codeproject.com/Articles/759331/Interview-Questions-Answers-Windows-Communication) and [WCF Security](https://www.codeproject.com/articles/36732/wcf-faq-part-3-10-security-related-faq)     
10) [Reasons to use ORM](https://www.quora.com/What-are-the-reasons-to-use-an-ORM), [EF 6 Docs](https://docs.microsoft.com/en-us/ef/ef6/), [EF Inheritance](https://weblogs.asp.net/manavi/inheritance-mapping-strategies-with-entity-framework-code-first-ctp5-part-1-table-per-hierarchy-tph), [EF Fluent API Relationships](https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/relationships), [EF DBCommand Interceptors](https://docs.microsoft.com/en-us/ef/ef6/fundamentals/logging-and-interception), [EF Migrations](https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/migrations/), [Dapper vs EF](https://entityframework.net/ef-vs-dapper) and [Dapper Docs](https://dapper-tutorial.net/dapper)     
11) [SignalR Docs](https://docs.microsoft.com/en-us/aspnet/signalr/)      
12) [Single Page Web Applications](https://www.manning.com/books/single-page-web-applications) amd [Pro Single Page Applications](https://www.apress.com/gp/book/9781430266730) for SPAs            
13) [FluentHTML](https://github.com/loresoft/FluentHtml/tree/master/Source/FluentHtml/Fluent), [Fluent Bootstrap](http://fluentbootstrap.com/GettingStarted), [Fluent HTML for PHP](https://github.com/fewagency/fluent-html), [HTML Object](https://github.com/SpoonX/html-object) and [Tag Builder](https://github.com/rwhitmire/tag-builder)             
14) [Offline First Web Development](https://www.packtpub.com/web-development/offline-first-web-development) and [Building real-time collaborative offline-first apps with React, Redux, PouchDB and WebSockets](http://blog.yld.io/2015/11/30/building-realtime-collaborative-offline-first-apps-with-react-redux-pouchdb-and-web-sockets/#.V2__9DXuMQ0)      
15) [Google's Web Fundamentals](https://developers.google.com/web/fundamentals/)         

**If at all this codebase is migrated to .NET Core then hopefully [ASP.NET Core Documentation](https://docs.asp.net/en/latest/) and [Porting to .NET Core](https://blogs.msdn.microsoft.com/dotnet/2016/02/10/porting-to-net-core/) will be pretty much helpfull.But currently lots of .NET Framework stuffs are not supported by the current .NET Core version as verified by [.NET Portability Analyzer Tool](https://visualstudiogallery.msdn.microsoft.com/1177943e-cfb7-4822-a8a6-e56c7905292b).Also don't have any plans to have a mix and match of .NET Framework and .NET Core environment working together since that would have its own challenges(didn't do any thorough analysis though) and the whole point of using .NET(wholly) for LINUX/MAC is missing in such an approach(although one might suggest to deploy .NET Framework code as a Web Service deployed in a Windows machine while the .NET Core code deployed in some LINUX/MAC machine consuming the Web Service but for sure, that would have its own challenges).Anyways, that's secondary and so MIGHT be taken care at some later point of time.

Other Good Resources – Most of the references mentioned above are really good(especially for developing this Application Framework) but the resources mentioned below can hopefully make one a better Coder/Designer/Architect/Systems Programmer –>
1.	Coding ->        
  • Some good resources in .NET space are [.NET Docs](https://opbuildstorageprod.blob.core.windows.net/output-pdf-files/en-us/VS.core-docs/live/docs.pdf), [C# 6.0 in a Nutshell]( http://www.albahari.com/nutshell/about.aspx), [C# in Depth]( http://csharpindepth.com/),   [CLR Via C#](http://www.wintellect.com/devcenter/jeffreyr/what-s-new-in-clr-via-c-4th-edition-as-compared-to-the-3rd-edition), 
  [.NET 4.0 Generics Beginner’s Guide]( https://www.packtpub.com/application-development/net-40-generics-beginner%E2%80%99s-guide),       [LINQ 101](https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b), [Dependency Injection in .NET]                          (https://www.manning.com/books/dependency-injection-in-dot-net-second-edition), [AOP in .NET](https://www.manning.com/books/aop-in-net)   ([Aspect-Oriented Programming, Interception and Unity 2.0](https://msdn.microsoft.com/en-us/magazine/gg490353.aspx) & 
  [Run-time AOP   vs Compile-time AOP](https://stackoverflow.com/questions/39448543/run-time-aop-vs-compile-time-aop)), [MetaProgramming in .NET]( https://www.manning.com/books/metaprogramming-in-dot-net), [Pro DLR in .NET 4.0](http://www.apress.com/9781430230663), [Concurrency in C# Cookbook]( http://shop.oreilly.com/product/0636920030171.do),[Learn Roslyn Now Series]( https://joshvarty.wordpress.com/learn-roslyn-now/), [.NET Reactive Extension Resources](http://stackoverflow.com/questions/1596158/good-introduction-to-the-net-reactive-framework), [Akka.NET Resources](http://getakka.net/docs/Resources), [Awesome .NET](https://github.com/quozd/awesome-dotnet#api), [.Net libraries that make your life easier](https://github.com/tallesl/net-libraries-that-make-your-life-easier), [.NET Framework Performance](https://docs.microsoft.com/en-us/dotnet/framework/performance/), [Awesome .NET Performance](https://github.com/adamsitnik/awesome-dot-net-performance)(for overall website performance, refer [My Web Site is so slow… And I don't know what to do about it!](https://blogs.iis.net/thomad/my-web-site-is-so-slow-and-i-don-t-know-what-to-do-about-it), [8 ways to improve ASP.NET Web API performance](http://blog.developers.ba/8-ways-improve-asp-net-web-api-performance/)) and [Awesome .NET Core](https://github.com/thangchung/awesome-dotnet-core).Other Performance texts that can be referred are [C# 7 and .NET Core 2.0 High Performance](https://prod.packtpub.com/in/application-development/c-7-and-net-core-20-high-performance), [ASP.NET Core 2 High Performance](https://prod.packtpub.com/in/application-development/aspnet-core-2-high-performance-second-edition) and [ASP.NET Site Performance Secrets](https://prod.packtpub.com/in/web-development/aspnet-site-performance-secrets)           
                 
  • A coder/programmer/developer can also opt for peeking into other languages/paradigms as well (via which one can use some unique aspect of some programming language into his/her favorite programming language to develop something cool or can become a Polyglot Programmer) and for that, one can refer [Pragmatic Bookshelf’s 7 in 7 series](https://pragprog.com/categories/7in7).Also do refer [The Best Programming Languages for Each Situation](https://tomassetti.me/best-programming-languages/) to geta gist of the right language to be used for the job.            
              
  • An open source server framework which is in quite hype nowadays is Node.js and for that, one can refer - [You don’t know JS Series]( https://github.com/getify/You-Dont-Know-JS ),[Stoyan Stefanov's JS Books](http://www.amazon.com/Stoyan-Stefanov/e/B002BLXYIG),[Nicholas C. Zakas' JS Books](http://www.amazon.com/Nicholas-C.-Zakas/e/B001IGUTOC), [Learning JavaScript Design Patterns](https://addyosmani.com/resources/essentialjsdesignpatterns/book/),[Almost Anything related to Node.js](https://blog.risingstack.com/),[Node.js in Action](https://www.manning.com/books/node-js-in-action),[Node.js Design Patterns](https://www.nodejsdesignpatterns.com/), [Node.js Architecture slides from Slideshare](http://www.slideshare.net/search/slideshow?searchfrom=header&q=node.js+architect) and [JS material available at MDN]( https://developer.mozilla.org/en-US/docs/Web/JavaScript).For Typescript, refer the [Typescript docs](https://www.typescriptlang.org/docs/home.html)              
                 
  • Although the JavaScript world has been moving towards Object Orientation(ES6 and ES7) but the irony is that the traditional Object Oriented languages like Java, C# have been moving more towards the functional side and for functional approaches, one can refer(mainly JS and .NET based language resources) - [So you want to be a Functional Programmer](https://medium.com/@cscalfani/so-you-want-to-be-a-functional-programmer-part-6-db502830403#.5noh8ieb8), [Functional Programming in C#](http://www.wrox.com/WileyCDA/WroxTitle/Functional-Programming-in-C-Classic-Programming-Techniques-for-Modern-Projects.productCd-0470744588.html), [LINQ and Functional Programming via C#](http://weblogs.asp.net/dixin/linq-via-csharp), [Learning F#](http://fsharp.org/learn.html), [Functional JavaScript](http://shop.oreilly.com/product/0636920028857.do), [Functional Programming in Javascript](https://www.packtpub.com/web-development/functional-programming-javascript) and [Persistent DataStructure](https://en.wikipedia.org/wiki/Persistent_data_structure).For Patterns on Functional Programming, refer [FP Design Patterns](https://www.youtube.com/watch?v=E8I19uA-wGY), [Where are all the Functional Programming Design Patterns](http://softwareengineering.stackexchange.com/questions/89273/where-are-all-the-functional-programming-design-patterns)(Check for the answer by Corbin March) and [Does Functional Programming Replace GoF Design Patterns](http://stackoverflow.com/questions/327955/does-functional-programming-replace-gof-design-patterns).           
                    
  • And for Unit Testing, [The Art of Unit Testing]( http://artofunittesting.com/) seems to be the best resource.For [BDD](https://en.wikipedia.org/wiki/Behavior-driven_development) using .NET refer [Specflow docs](https://specflow.org/documentation/)       
              
  • For SQL one can refer [Joe Celko's Books](https://en.wikipedia.org/wiki/Joe_Celko#Bibliography), [Introduction to Analytic Functions](http://allthingsoracle.com/introduction-to-analytic-functions-part-2/), [Execution Plan Basics](https://www.red-gate.com/simple-talk/sql/performance/execution-plan-basics/), Introductory SQL Big O Complexity Analysis - [I](https://stackoverflow.com/questions/1347552/what-is-the-big-o-for-sql-select) & [II](https://www.sqlservercentral.com/Forums/Topic730611-8-1.aspx), [SQL Server Performance Tuning & Design](http://littlekendra.com/2016/10/11/books-to-learn-sql-server-performance-tuning-and-database-design/) and SQL Server MVP Deep Dives - [Vol I](https://www.manning.com/books/sql-server-mvp-deep-dives) & [Vol II](https://www.manning.com/books/sql-server-mvp-deep-dives-volume-2).     
  
  
          
  
  


