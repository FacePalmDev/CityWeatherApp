Feature: Adding Cities
	As an Api consumer
	I want to be able to add new cities
	So that the system can be continually extended to serve new clients

Scenario: User attempts to add the first new city
	Given That no example cities exist in the system
	When the system is instructed to add the city "Oxford"
	Then the city "Oxford" should be present in the system
	And the total number of cities should equal 1.

Scenario: User attempts to add additional cities
	Given That example cities already exist in the system
	But  the city "Oxford" does not exist in the system
	When the system is instructed to add the city "Oxford"
	Then the city "Oxford" should be present in the system
	And the total number of cities should equal 3.


Scenario: User attempts to add a city with no name defined
	Given That no example cities exist in the system
	When the system is instructed to add the city "Oxford"
	Then a validation exception should be thrown
	And the validation exception message should be "Nothing"

###
# Decided to remove this as it was an assumtion. 
# The requirement for search suggests that many cities can be returned. 
# though I initially assumed this would be for partial city name matches I think I
# I should probably verify this with the relevant subject matter expert(s).
#
#Scenario: User attempts to add a city that already exists
#	Given That example cities already exist in the system
#	When the system is instructed to add the city "London"
#	Then the system should raise an error saying "The current city already exists".
###
