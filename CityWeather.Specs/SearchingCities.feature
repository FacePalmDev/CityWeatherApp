Feature: SearchingCities
	As an Api consumer
	I want to be able to search for cities
	So that I can view the city, weather and country data.

Scenario Outline: Search for present city 
	Given The city "London" exists in the system with country code "GB"
	And The city "Tokyo" exists in the system with country code "JP"
	And The city "Manchester" exists in the system with country code "GB"
	When The search term "<searchTerm>" is used
	Then The search results should contain "<result1>"
	And The search results should contain "<result2>"
	And The number of results returned should be <resultCount>
	And The search results should contain country data for "<country1>"
	And The search results should contain country data for "<country2>"

# todo: isn't ideal but will suffice for now.
Examples:
	| searchTerm  | result1     | result2     | country1 | country2 | resultCount |
	| o			  | London      | Tokyo		  | GB       | JP       | 2           |
	| man         | Manchester  | Manchester  | GB       | GB       | 1           |
	| Tokyo		  | Tokyo		| Tokyo		  | JP       | JP       | 1           |


Scenario: Search for non-present city
	Given The city "London" exists in the system with country code "GB"
	And The city "Manchester" exists in the system with country code "GB"
	When The search term "Londonderry" is used
	Then The number of results returned should be 0