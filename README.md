# PubSubSample

This is a PubSub (observer pattern) demonstration

##Prelude
PubSub stands for publish and subscribe. it is a pattern
where sender of message(s) referred to as publishers will send the messages
to it's recipient(s) also referred to as subscribers.

## Summary
This demonstration is done in c# and does not use external components.


* These codes were developed on a windows 10 machine using visual studio 2017.


## Prerequisites
1. Visual Studio 2017 (recommended), at least community edition
1. .Net Framework 4.6 
2. NUnit 3.10.1
3. NUnit3TestAdapter 3.10.0


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

