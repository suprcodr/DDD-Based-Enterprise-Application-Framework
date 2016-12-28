# Domain Driven Design Based Enterprise Application Framework

An opinionated Enterprise Application Framework based on different Patterns, Principles and Practices of Domain Driven Design.Although not all tactical and strategic Patterns, Principles and Practices of DDD are in place but the most important ones(the ones that are used almost in any Enterprise app) are in place.Will try to connect most of the dots in future with time.This being a Framework, any application specific stuff is not there and will never be there in the Core code.

This framework is also helpful in scenarios wherein one needs to interact with different Integration technologies using different .NET based access technologies(can be DBs, SOAP or RESTFUL Web Services or MQs or File Sysstem or an LDAP or any other imaginable data source).Another possible scenario can be in a CQRS(Command Query Responsibility Seggregation) environment wherein the commands are processed in an RDBMS like SQL Server whereas the queries are executed to fetch data from NOSQL DBs.Also, once this framework is completed and if someone uses this framework, atleast for the development of a SPA based Web Application or Website or a Mobile Web application, ideally he/or she should need to work only on Domain Modelling(i.e. mainly Domain,Domain Services and Application Services) and UI stuffs(there might be some requirement for extending some extensibility points which are already provided out of the box or creating new extensibility points all-together or some other configuration stuff changes required like DI container specific stuffs or ORM configurations if RDBMS is used etc).That doesn't mean that all these can be applied only for Web apps or Websites or Mobile Web Application only but in-fact, parts of this framework can be applied to Business Process Management and Integration projects as well.

But please don't use this framework for some simple domain.DDD is more about domain modelling for complex domains using concepts of Entities,Value Objects, Aggregates etc and separating out your Business functionalities from your technical functionalities. Although this framework provides(or will provide) most of the technical functionalities(out of the box, including the source code) used in an Enterprise app and some base level classes for dealing with Entities,Value Objects, Aggregates etc but it's not necessary that one is going to need every bit of it. So use this framework(or may be just parts of the framework) deligently after analyzing the requirements for your app meticulously.

Implementation Overview-> 
Here the CommandRepository(for persisting data) and QueryableRepository(for querying data) are in-memory representation of some external source - mainly DBs(but can be extended to Web Services or MQ interactions as well or any other imaginable data source for that matter).
The CommandRepository class needs instances of concrete implementation of BaseUnitOfWork and ICommand which can be injected using some DI Framework like Unity.

UnitOfWork (implements IUnitOfWork members) - De-couples the logic to do atomic transactions across Dbs(can be extended to use Web Services/MQs or some other data source as well to be part of the Transaction) using different DB access technologies(again can be extended to use Web Service/MQs or any other data source). UnitOfWork based transactions can be applied at the API or Domain Services or Repository layer.

ICommand & IQuery- Provides contracts to deal with different DB technologies viz. ADO.NET,Enterprise Library or ORMs like Entity FrameWork Code First etc and different DBs(current implementation supports mainly SQL Server - but as mentioned eralier also, can be extended to support other DB types as well).

N.B.-> If one wants to think of any imaginable data source as Repository then atleast for the query side it's better to have a IQueryable provider for the same(atleast to use this framework seamlessly). For an exhaustive list of open source IQueryable providers, one can visit [Linq to Everything](https://blogs.msdn.microsoft.com/charlie/2008/02/28/link-to-everything-a-list-of-linq-providers/) (well, it's almost EVERYTHING).If some imaginable data source is not mentioned in the afore-mentioned list then one can build his/her own IQueryable provider and hopefully the articles viz. [LINQ: Building an IQueryable provider series](https://blogs.msdn.microsoft.com/mattwar/2008/11/18/linq-building-an-iqueryable-provider-series/), [Building Custom LINQ Enabled Data Providers](https://blogs.msdn.microsoft.com/tommer/2007/04/20/building-custom-linq-enabled-data-providers-using-iqueryablet/), [Creating LINQToTwitter library using LinqExtender](http://weblogs.asp.net/mehfuzh/creating-linqtotwitter-library-using-linqextender) and [Writing A Custom LINQ Provider With Re-linq](http://fairwaytech.com/2013/03/writing-a-custom-linq-provider-with-re-linq/) can be helpful in doing the same.And if anyone builds any LINQ to Something(or "Anything") provider, then please don't forget to share it with the world.

Pending Tasks ->

• Incorporation of some tactical DDD stuffs(mainly the common framework elements).

• Trying exploring and incorporating Dapper(a Micro-ORM - Micro ORMs may not provide you some functionalities like UnitOfWork out of the box like that of an ORM but performance wise they are way better compared to ORMs), Event Stores and Grid Based Storage.

• Incorporation of some Restful stuffs which are commonly used in most Enterprise Apps.

• Whatever done till now is all Orchestrations rather than Event Driven Choreographies.Even the async await based request reply 
  mechanisms are also actually Orchestrations. True Fire and Forget Event Driven Choreographies(may be with some nominal acknowledgement sent to the requester) following Eventually Consistent approach  WILL ALSO BE TRIED, at the Web API Layer using "Event Driven Rest" and at the Business Layer using [Zero  MQ](http://zeromq.org/).[Zero  MQ](http://zeromq.org/) was designed from the ground up, keeping in mind stock trading apps wherein very high throughput and very low latency are required, as discussed [here](http://aosabook.org/en/zeromq.html).         
  N.B. -> One can refer the paper - [Your Coffe Shop Doesn't use 2 phase commit](http://www.enterpriseintegrationpatterns.com/docs/IEEE_Software_Design_2PC.pdf)(written by the Integration genius - Gregor Hohpe, co-author of the Integration Bible viz. [Enterprise Integration Patterns](http://www.enterpriseintegrationpatterns.com/)) to see how apps can be implemented without using Transactional Consistency.

• Testing BulkOperations using SQL Express Edition.

• Fixing WCF related Unit Test Case(s).

• Redesign Caching stuffs to support in-memory caching or some scalable option like Windows AppFabric or Redis(a scalable NOSQL
  option). Ideally, should be designed in a pluggable way to support any cool Caching mechanism coming in future as well.Also should use some AOP or attribute(annotation) based approach to apply Caching or invalidating the Cache else it becomes very hectic to apply these cross cutting concerns everywhere within a large application.
  
• Exploring Single Page Applications and building a Fluent UI Framework using which the UI layout(HTML + CSS) and UI  
  Behaviours(using Javascript) can be coded in a fluent way using Javascript.IF POSSIBLE, will try to have plugin features wherein SPA Frameworks like Angular or React can be plugged in as and when required.Will also try to incorporate Offline-First capabilities.All these probably will have a Github Project of its own and that will be used in this project.This is going to take quite some time since lots of exploration needs to be done in this area.

• Ultimately building a SAAS Framework based on all the above stuffs.

• Fixing or suppressing the Warnings generated by MS Code Analysis Tool (currently, Code Analysis Settings is set to "Microsoft
  Basic Design Guidelines").

• Also need to Run the Code Metrics to check everything is as per standards.

References(not that everything mentioned below is referred to build this framework, but atleast some bits of each of these awesome resources mentioned below have been referred or will be referred) -   
 1) [Patterns, Principles and Practices of Domain Driven Design](http://www.wrox.com/WileyCDA/WroxTitle/Patterns-Principles-and-Practices-of-Domain-Driven-Design.productCd-1118714709.html)  
 2) [Implementing Domain Driven Design](https://vaughnvernon.co/?page_id=168)    
 3) [Javascript Domain Driven Design](https://www.packtpub.com/web-development/javascript-domain-driven-design)  
 4) [Coding for Domain Driven Design](https://msdn.microsoft.com/en-us/magazine/dn342868.aspx)  
 5) [Domain Driven Design Wiki](https://en.wikipedia.org/wiki/Domain-driven_design)  
 6) Some very good samples to look out for DDD are [Domain-Driven Design Using a Trading Application Example](https://archfirst.org/bullsfirst/), [DDD E-Commerce Sample](https://github.com/zkavtaskin/Domain-Driven-Design-Example), [Domain Driven Design Using SpringTrader](https://blog.pivotal.io/pivotal/products/springone-video-domain-driven-design-using-springtrader) and [Click's Hexagonal Domain Driven Architecture](https://github.com/ClickTravel/Cheddar). Some other good open source DDD apps are like- [I](http://stackoverflow.com/questions/152120/are-there-any-open-source-projects-using-ddd-domain-driven-design) and [II](http://stackoverflow.com/questions/540130/good-domain-driven-design-samples).   
 7) [CQRS Wiki](https://en.wikipedia.org/wiki/Command%E2%80%93query_separation#Command_Query_Responsibility_Segregation), [How Eventuate Works](http://eventuate.io/howeventuateworks.html), [Rinat Abdullin On CQRS](https://abdullin.com/tags/cqrs/), [CQRS Myths](https://lostechies.com/jimmybogard/2012/08/22/busting-some-cqrs-myths/), [When To Avoid CQRS](http://udidahan.com/2011/04/22/when-to-avoid-cqrs/) and [CQRS Examples](http://stackoverflow.com/questions/5043513/cqrs-examples-and-screencasts)      
 8) [Building MicroServices](http://shop.oreilly.com/product/0636920033158.do) and [MicroServices in .NET](https://www.manning.com/books/microservices-in-net)(mainly the source code)       
 9) [HTTP: The Definitive Guide](shop.oreilly.com/product/9781565925090.do), [Restful Web Services Cookbook](http://shop.oreilly.com/product/9780596801694.do), [Restful Web APIs](http://shop.oreilly.com/product/0636920028468.do) and [Rest in Practice](http://shop.oreilly.com/product/9780596805838.do)  
 10) [Almost Anything and Everything about ASP.NET Web API](http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api)(including [ASP.NET WEB API 2: HTTP MESSAGE LIFECYLE](http://www.asp.net/media/4071077/aspnet-web-api-poster.pdf)) and [Designing Evolvable Web APIs with ASP.NET](http://chimera.labs.oreilly.com/books/1234000001708)       
 11) Some good Hypermedia Resources(needed for Event Driven Rest) - [The value proposition of Hypermedia](https://lostechies.com/jimmybogard/2014/09/23/the-value-proposition-of-hypermedia/), [Level Up your Web API with Hypermedia](https://channel9.msdn.com/Events/TechEd/NewZealand/2013/DEV305), [Generating Hypermedia links in ASP.NET Web API](http://benfoster.io/blog/generating-hypermedia-links-in-aspnet-web-api) and [Building Hypermedia Web APIs with ASP.NET Web API](https://msdn.microsoft.com/en-us/magazine/jj883957.aspx)    
 12) [24 Deadly Sins of Software Security](http://www.amazon.in/Deadly-Sins-Software-Security-Programming/dp/0071626751), [Federated Identity](https://en.wikipedia.org/wiki/Federated_identity),[Guide to Claims based Identity and Access Control](https://msdn.microsoft.com/en-us/library/ff423674.aspx) and [An Updated Look At Choosing Between OAuth2 and SAML](https://www.mutuallyhuman.com/blog/2015/07/17/an-updated-look-at-choosing-between-oauth2-and-saml/)  
 13) [SignalR Programming in Microsoft ASP.NET](https://blogs.msdn.microsoft.com/microsoft_press/2014/02/13/new-book-signalr-programming-in-microsoft-asp-net/) and [SignalR Blueprints](https://www.packtpub.com/web-development/signalr-blueprints)         
 14) [Single Page Web Applications](https://www.manning.com/books/single-page-web-applications)  
 15) [Telerik Academy's ShowcaseSystem(having a quite good SPA sample using Angular.js)](https://github.com/TelerikAcademy/ShowcaseSystem).Some other resources which might be looked out are [Awesome Angular JS](https://github.com/gianarb/awesome-angularjs), [Awesome Angular 2](https://github.com/AngularClass/awesome-angular2), [Awesome Angular](https://github.com/AngularClass/awesome-angular2),[Awesome React](https://github.com/enaqx/awesome-react), [Awesome React Native](https://github.com/jondot/awesome-react-native), [React Flux vs React Redux](http://stackoverflow.com/questions/32461229/why-use-redux-over-facebook-flux), [Awesome React Redux](https://github.com/xgrommx/awesome-redux),[Building realtime collaborative offline-first apps with React, Redux, PouchDB and WebSockets](http://blog.yld.io/2015/11/30/building-realtime-collaborative-offline-first-apps-with-react-redux-pouchdb-and-web-sockets/#.V2__9DXuMQ0)  and [Awesome Offline First](https://github.com/pazguille/offline-first)    
 16)[FluentHTML](https://github.com/loresoft/FluentHtml/tree/master/Source/FluentHtml/Fluent), [Fluent Bootstrap](http://fluentbootstrap.com/GettingStarted), [Fluent HTML for PHP](https://github.com/fewagency/fluent-html), [HTML Object](https://github.com/SpoonX/html-object) and [Tag Builder](https://github.com/rwhitmire/tag-builder)      
 17) [Offline First Web Development](https://www.packtpub.com/web-development/offline-first-web-development)
 
 *** Also, if at all this codebase is migrated to .NET Core then hopefully [ASP.NET Core Documentation](https://docs.asp.net/en/latest/) and [Porting to .NET Core](https://blogs.msdn.microsoft.com/dotnet/2016/02/10/porting-to-net-core/) will be pretty much helpfull.But currently lots of .NET Framework stuffs are not supported by the current .NET Core version as verified by [.NET Portability Analyzer Tool](https://visualstudiogallery.msdn.microsoft.com/1177943e-cfb7-4822-a8a6-e56c7905292b).Also don't have any plans to have a mix and match of .NET Framework and .NET Core environment working together since that would have it's own challenges(didn't do any thorough analysis though) and the whole point of using .NET(wholly) for LINUX/MAC is missing in such an approach(although one might suggest to deploy .NET Framework code as a Web Service deployed in a Windows machine while the .NET Core code deployed in some LINUX/MAC machine consuming the Web Service but for sure, that would have it's own challenges).Anyways, that's secondary and so MIGHT be taken care at some later point of time.
 
 Other Good Resources – Most of the references mentioned above are really good(especially for developing this Application Framework) but the resources mentioned  below can hopefully make you a better Coder/Designer/Architect/Systems Programmer –>         
 
 1) Coding -> Some good resources in .NET space are [C# 6.0 in a Nutshell]( http://www.albahari.com/nutshell/about.aspx), [C# in Depth]( http://csharpindepth.com/), [CLR Via C#](http://www.wintellect.com/devcenter/jeffreyr/what-s-new-in-clr-via-c-4th-edition-as-compared-to-the-3rd-edition), [.NET 4.0 Generics Beginner’s Guide]( https://www.packtpub.com/application-development/net-40-generics-beginner%E2%80%99s-guide), [MetaProgramming in .NET]( https://www.manning.com/books/metaprogramming-in-dot-net), [Pro DLR in .NET 4.0](http://www.apress.com/9781430230663), [Concurrency in C# Cookbook]( http://shop.oreilly.com/product/0636920030171.do),[Learn Roslyn Now Series]( https://joshvarty.wordpress.com/learn-roslyn-now/),[Domain Specific Language in .NET] (http://udooz.pressbooks.com/), [.NET Reactive Extension Resources](http://stackoverflow.com/questions/1596158/good-introduction-to-the-net-reactive-framework), [Akka.NET Resources](http://getakka.net/docs/Resources) and [Awesome .NET](https://github.com/quozd/awesome-dotnet#api). Some very good DSL(Domain Specific Language) resources are like [Domain Specific Languages](http://martinfowler.com/books/dsl.html) by Martin Fowler and [Language Implementation Patterns](https://pragprog.com/book/tpdsl/language-implementation-patterns) by Terrence Parr(author of [ANTLR](https://en.wikipedia.org/wiki/ANTLR)) but probably before going into the depths of DSLs(by going through the afore-mentioned texts), a refreshing overview would be to go through [Implementing Programming Languages using C# 4.0](http://www.codeproject.com/Articles/272494/Implementing-Programming-Languages-using-Csharp). A coder/programmer/developer can also opt for peeking into other languages/paradigms as well (via which one can use some unique aspect of some programming language into his/her favorite programming language to develop something cool or can become a Polyglot Programmer) and for that, one can refer [Pragmatic Bookshelf’s 7 in 7 series] (https://pragprog.com/categories/7in7). A programming paradigm which is in quite hype nowadays is Node.js and for that, one can refer - [You don’t know JS Series]( https://github.com/getify/You-Dont-Know-JS ),[Stoyan Stefanov's JS Books](http://www.amazon.com/Stoyan-Stefanov/e/B002BLXYIG),[Nicholas C. Zakas' JS Books](http://www.amazon.com/Nicholas-C.-Zakas/e/B001IGUTOC), [Learning Javascript Design Patterns](https://addyosmani.com/resources/essentialjsdesignpatterns/book/),[Almost Anything related to Node.js](https://blog.risingstack.com/),[Node.js in Action](https://www.manning.com/books/node-js-in-action),[Node.js Design Patterns](https://www.nodejsdesignpatterns.com/), [Node.js Architecture slides from Slideshare](http://www.slideshare.net/search/slideshow?searchfrom=header&q=node.js+architect) and [JS material available at MDN]( https://developer.mozilla.org/en-US/docs/Web/JavaScript). Although the Javascript world has been moving towards Object Orientation(ES6 and ES7) but the irony is that the traditional Object Oriented languages like Java,C# have been moving more towards the functional side and for functional approaches, one can refer(mainly JS and .NET based language resources) - [So you want to be a Functional Programmer](https://medium.com/@cscalfani/so-you-want-to-be-a-functional-programmer-part-6-db502830403#.5noh8ieb8), [Functional Programming in C#](http://www.wrox.com/WileyCDA/WroxTitle/Functional-Programming-in-C-Classic-Programming-Techniques-for-Modern-Projects.productCd-0470744588.html), [LINQ and Functional Programming via C#](http://weblogs.asp.net/dixin/linq-via-csharp), [Learning F#](http://fsharp.org/learn.html), [Functional Javascript](http://shop.oreilly.com/product/0636920028857.do), [Functional Programming in Javascript](https://www.packtpub.com/web-development/functional-programming-javascript) and [Persistent DataStructure](https://en.wikipedia.org/wiki/Persistent_data_structure). And for Unit Testing, [The Art of Unit Testing]( http://artofunittesting.com/) seems to be the best resource.
 
 2) Design, Architecture and DevOps – Some good resources in general for this space are [Patterns Literature]( https://insightsdelight.wordpress.com/2011/10/12/patterns-literature/), [UML Guide](https://sourcemaking.com/uml), [UML Notations](http://www.tutorialspoint.com/uml/uml_basic_notations.htm), [RDBMS Data Modelling]( http://www.agiledata.org/essays/dataModeling101.html), [Data Access for Highly-Scalable Solutions: Using SQL, NoSQL, and Polyglot Persistence](https://msdn.microsoft.com/en-us/library/dn271399.aspx), [NOSQL Data Modelling](https://highlyscalable.wordpress.com/2012/03/01/nosql-data-modeling-techniques/), [O’Reilly’s Beautiful X Series]( http://product.hubspot.com/bid/24069/O-Reilly-s-Beautiful-X-Series), [Anything from WSO2(is just awesome)](http://wso2.com/), [The Architecture of Open Source Applications]( http://aosabook.org/en/index.html), [Application Architecture Posts by Martin Fowler]( http://martinfowler.com/tags/application%20architecture.html), [Application Integration Posts by Martin Fowler]( http://martinfowler.com/tags/application%20integration.html), [Enterprise Architecture Posts by Martin Fowler]( http://martinfowler.com/tags/enterprise%20architecture.html), [Practical SOA For the Solution Architect]( https://www.youtube.com/watch?v=1KXKppaOgtY), [Almost anything and everything on SOA from Manning](https://www.manning.com/catalog#section-58), [Microservices Architecture]( http://microservices.io/), [O’Reilly’s Software Architecture Series]( http://www.oreilly.com/software-architecture-video-training-series.html), [Architectural Styles and Patterns]( https://en.wikipedia.org/wiki/Architectural_pattern) (including [Hexagonal Architecture]( https://www.infoq.com/news/2014/10/exploring-hexagonal-architecture), [Onion Architecture]( http://blog.thedigitalgroup.com/chetanv/2015/07/06/understanding-onion-architecture/) and [Microkernel Architecture]( http://viralpatel.net/blogs/microkernel-architecture-pattern-apply-software-systems/ )), [Multi Layered Architectures in .NET](http://www.mono.hr/Pdf/Muilt-Layered%20Architectures%20in%20.Net-Web.pdf), [Are you a Software Architect](https://www.infoq.com/articles/brown-are-you-a-software-architect), [Infrastructure as Code](https://en.wikipedia.org/wiki/Infrastructure_as_Code), [The Art of Monitoring](https://www.artofmonitoring.com/), [DevOps in Practice] (https://pragprog.com/book/d-devops/devops-in-practice), [Concurrent Programming for Scalable Web Architectures](http://berb.github.io/diploma-thesis/original/index.html), [Enterprise Architecture Frameworks](https://msdn.microsoft.com/en-us/library/bb466232.aspx), [Gartner's Hype Cycle For Enterprise Architecture](https://www.gartner.com/doc/3384417/hype-cycle-enterprise-architecture-) and [Gartner's Hype Cycle For Emerging Technologies](http://www.gartner.com/newsroom/id/3412017). Some good resources in this space from the Software Engineering perspective are [Architecting High Performing, Scalable and Available Enterprise Web Applications]( http://www.amazon.in/Architecting-Performing-Available-Enterprise-Applications/dp/0128022582/ref=la_B00OTWHRRO_1_1?s=books&ie=UTF8&qid=1441731036&sr=1-1 ), [Just Enough Software Architecture]( http://www.amazon.in/Just-Enough-Software-Architecture-Risk-Driven/dp/0984618104)(some  [recommended texts]( http://georgefairbanks.com/software-architecture/book-recommendations/ ) by this author), [Software Architecture for Developers]( https://leanpub.com/software-architecture-for-developers), [Architecture Principles : The cornerstones of Enterprise Architecture] (http://www.amazon.com/Architecture-Principles-Cornerstones-Enterprise-Engineering/dp/3642202780/ref=sr_1_78?s=books&ie=UTF8&qid=1308252595&sr=1-78 ), [Non Functional Requirements](https://www.youtube.com/watch?v=AjLWQg6jGIA), [Scalability Resources](http://akfpartners.com/assets/images/general/AKF_publications_template.pdf), [Architectural Tradeoff Analysis Method](http://www.sei.cmu.edu/library/assets/icse98-2.pdf), [Capacity Planning Resources](https://www.quora.com/What-are-some-good-books-to-learn-capacity-planning), [DevOps : A Software Architect’s Perspective ]( http://ssrg.nicta.com.au/projects/devops_book/) and [Other Software Architecture Resources]( https://www.linkedin.com/pulse/10-must-read-books-software-architects-ganesh-samarthyam ).Again from the Systems Programming and Distributed Computing perspective, some good resources are like [Distributed Computing for Fun and Profit]( http://book.mixu.net/distsys/ebook.html), [Awesome Distributed Systems](https://github.com/theanalyst/awesome-distributed-systems),  [High Scalability All Time Favorites]( http://highscalability.com/all-time-favorites/), [High Scalability Real Life Architectures]( http://highscalability.com/blog/category/example), [All Things Distributed]( http://www.allthingsdistributed.com/)(Amazon CTO’s blog), [Mechanical Sympathy]( http://mechanical-sympathy.blogspot.in/ )(blog of one of the brainchild behind the superb [LMAX Architecture]( http://martinfowler.com/articles/lmax.html)), [Operating System Support for Warehouse Scale Computing]( https://www.cl.cam.ac.uk/~ms705/pub/thesis-submitted.pdf), [BigData](https://www.manning.com/books/big-data) and [The Not so Small list of almost all Distributed Computing Resources](https://www.quora.com/What-are-some-good-resources-for-learning-about-distributed-computing-Why). And last but by no means the least, from a Cloud Computing perspective, some good resources are like [Cloud Computing Patterns](http://www.cloudcomputingpatterns.org/), [Cloud Patterns](http://www.cloudpatterns.org/), [MS Azure Cloud Development resources from Patterns and Practices](https://msdn.microsoft.com/en-us/library/ff898430.aspx), [MS Azure Solutions](https://azure.microsoft.com/en-in/), [Azure .NET SDK Capabilities](https://azure.microsoft.com/en-us/documentation/api/), [MS Azure Certifications](https://buildazure.com/2015/12/09/microsoft-azure-certification-where-to-start/), [AWS Architecture Centre](https://aws.amazon.com/architecture/?nc1=f_cc), [AWS .NET SDK Capabilities](https://github.com/aws/aws-sdk-net), [AWS Security Centre](https://aws.amazon.com/security/?nc1=f_cc), [AWS Solutions](https://aws.amazon.com/solutions/), [AWS Certifications](https://aws.amazon.com/certification/) and [Guide to Open Source Cloud Computing Software](http://www.tomsitpro.com/articles/open-source-cloud-computing-software,2-754.html).
 
 *** Also,one can refer [Udacity Courses](https://www.udacity.com/courses/all)(alongwith [Downloads](https://www.udacity.com/wiki/downloads)), [Coursera Courses](https://www.coursera.org/courses?_facet_changed_=true&domains=computer-science&languages=en&query=free+courses&start=60), [eDX courses](https://www.edx.org/course), [Recurse](https://www.recurse.com/) and [Developer Y's CS Video Courses](https://github.com/Developer-Y/cs-video-courses) for overall breadth and depth of Computer Science and Engineering.  
 
 **** One of the best way to learn SPA,REST/MicroServices and DDD(including CQRS and Event Sourcing) is to grab some     
 existing good open source projects and then gather the requirements (from the  source code), analyze the requirements,     architect/design/implement the requirements(alongwith unit and integration  testing) using priciples of SPA,REST     
 /MicroServices and DDD(may be if needed, can apply parts/whole of this Framework for the same). Some intriguing     
 open source projects in this regard are -        
 a) ASP.NET - [ASP.NET(& .NET in general) Open Source Projects](https://www.asp.net/mvc/open-source) and [ASP.NET Samples](https://www.asp.net/aspnet/samples).A good article with regards to comparison of various ASP.NET Technologies is [WEB FORMS, MVC, SINGLE PAGE APP, WEB PAGES COMPARISON](http://prasadhonrao.com/web-forms-mvc-single-page-app-web-pages-comparison/).              
 b) E-Commerce - [NopCommerce](http://www.nopcommerce.com/), [SmartStoreNET](https://www.smartstore.com/en/net) and [Virto Commerce](https://virtocommerce.com/)     
 c) Trading - [StockSharp](https://github.com/StockSharp/StockSharp)      
 d) CMS - [Orchard](http://www.orchardproject.net/) and [Umbraco](https://umbraco.com/)       
 e) CRM - [SplendidCRM](http://www.splendidcrm.com/)      
 f) Personalization - [My Web Pages Starter Kit](https://mywebpagesstarterkit.codeplex.com/)     
 g) Web Portal - [DropThings](https://www.codeproject.com/articles/35193/web-2-0-ajax-portal-using-jquery-asp-net-3-5-silve) and [ASP.NET Portal Starter Kit](https://aspnetportal.codeplex.com/)        
 h) Social News - [Kigg](http://kigg.codeplex.com/)      
 i) Blog - [BlogEngine.NET](https://github.com/rxtur/BlogEngine.NET)   
 j) SOA - [.NET Stock Trader](https://blogs.msdn.microsoft.com/roberdan/2007/06/20/net-stocktrader-sample-application/)      
 k) Workflows(along-with some Utilities) - [NeoVolve.Toolkit](https://github.com/roryprimrose/Neovolve.Toolkit).This project is more of a toolkit, the utilities and concepts of which can be used to build REST/DDD based Workflow projects.Also watch out for WWF based PageFlow samples like [Rule Driven Pageflow / Workflow](https://code.msdn.microsoft.com/windowsapps/Rule-Driven-Pageflow-fc765617) and   [ASP.Net Page Navigation using Workflow 4.0](http://www.c-sharpcorner.com/uploadfile/sridhar_subra/Asp-Net-page-navigation-using-workflow-4-0/).     
 l) Concurrency - [Parallel Programming Samples](https://code.msdn.microsoft.com/ParExtSamples) and [Parallel Programming Extras](https://blogs.msdn.microsoft.com/pfxteam/2010/04/04/a-tour-of-parallelextensionsextras/). Again,please note that these projects are not mentioned for learning SPA or REST or DDD principles directly but the underlying principles can be used for some REST/DDD based projects at the server side.      
 m) Angular.JS - [Telerik's Showcase System](https://github.com/TelerikAcademy/ShowcaseSystem).Probably the best resource to learn SPA using Angular.js.      
 
 N.B. -> It’s not that I have read/viewed everything mentioned above but yes, I have read/viewed a few of them (partially or completely) and many are yet to be even started(for reading) but all the resources mentioned above are some of the best resources(as per my interaction with some beautiful minds and my own exploration). Also, something not mentioned in the above list doesn't mean that it's not good - only that I am not aware of(or not my preference).

 P.S. -> Once completed, this DDD framework can be considered (as a whole or in parts) as a Reference Architecture for quite a variety of application scenarios. Ultimate goal is to build an Omni-Channel Offline-First Single-Page-Application based SaaS Framework using DDD and Restful API concepts (although parts of the framework can be used for a BPM and Integration Project as well).
