@pot
Feature: Pot Purchase Flow
An end-to-end or regression test for purchasing an event in dev1

Scenario: Buying a pot
	Given I am in dev
	And I press the menu 'PRODUKTER'
	And I press the option 'POT'
	When I press 'KÖP' to buy a pot
	And I press 'Fortsätt handla' to keep buying
	And I press 'KÖP' to buy a pot again
	And I press 'Gå vidare' to proceed to cart
	Then I get to the whole Klana flow until the succeed page
