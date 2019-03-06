
# CityWeather Api

## Things to clarify 
* Does the star rating system accept values like 4.5? I'll assume not for the moment.
* What specific country/weather summary data would the client like to see?
* Do the consumers have a specific structure they'd prefer the data in?

## Why not dotnetcore? 
I wanted to use dotnetcore but was having problems using specflow with it. As there was no requirement
for crossplatform functionality I assumed that the .NET Framework would be fine. 

## Some of your checkins are a little messy!
I know, at one point I got a little tired and started forgetting to check stuff in. It's not pretty and I should really know better.

## PostMan Scripts
I've included some postman scripts to help you test the api. Sure things might need a little tweaking to work on your machine (e.g. port numers etc...).

## Tools used 
* Serilog - Great logging extension, very versetile. I also chose the rolling file Sink so as not to clog the server up with logs.
* RestSharp - Simplifying RESTful requests
* Entity Framework 
* StructureMap - Dependency Injection chosen for it's simplicity. You also don't need to define every single map with default conventions. I felt this would reduce lines of code.
* AutoMapper - because who wants to spend all day mapping models to models? 
* SpecFlow - BDD Test runner allowing me to write out Gerkin Specs which are bound to integration tests.
* MSTest - Kept it quite basic for unit testing. 
* Moq - Again it's a nice simple mocking engine. I didn't need anything more complex.
* Fluent Assertions - For test readability.
* Resharper - I love it! Especially the continuous testing
* 
## Technical Debt
There were time constraints and sometimes in the real world a quick fix is needed. That doesn't mean I've forgotten about the potential issues. Each one I spotted I marked with a //todo. 

Unit test coverage could also be better but I didn't have enough time. In the real world, I'd continue to work on that after release. 
