# PubSubSample

This is a PubSub (observer pattern) demonstration

##Prelude
PubSub stands for publish and subscribe. it is a pattern
where sender of message(s) referred to as publishers will send the messages
to it's recipient(s) also referred to as subscribers.

## Summary
This demonstration is done in c# and does not use external components.
To view the simple demo, please checkout to the dev-01-simple branch.

* These codes were developed on a windows 10 machine using visual studio 2017.


## Prerequisites
1. Visual Studio 2017 (recommended), at least community edition
1. .Net Framework 4.6
2. NUnit 3.10.1
3. NUnit3TestAdapter 3.10.0
4. Moq 4.8.2


## Components

### Program
The program.cs contains the Main function (client) that uses the

### PubSubManager
The role of the PubSubManager is to contain business logic pertaining to the business rules and use case. It ties the service layer components together to fit the required work-flow. It implements the IManager to adhere to a particular standard (possibly the company standard)

### Message
A concrete publication that implements IPublisher.
This class fully implements the intended publishing mechanism

### ListAllSubscriberService
Service that retrieves and provides a list of subscribers. It Implements IService.

### PublisherService
Service that retrieves the publisher. It Implements IService

### EmailSubscriber
A pseudo service that can be used to implement an email library
to send data to email subscribers

### RESTSubscriber
A pseudo service that can be used to implement REST API calls

### ShellSubscriber
A pseudo service that can be used to send console messages

### SmsSubscriber
A pseudo service that can implement a sms library to send short messages
to subscribers.

###ValidationProvider
A simple validation provider PublisherValidator is available
to validate publisher data.


## Future consideration
1. The solution infrastructure should be re-factored into multiple projects for code size efficiency and to be made shareable.
2. The publisher abstraction can be introduced with generic to support data variety.