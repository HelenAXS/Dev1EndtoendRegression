@product
Feature: Product Purchase Flow
An end-to-end or regression test for purchasing an event in dev1

Scenario: Buying a product
	Given I am in dev
	And I press the menu 'PRODUKTER'
	When I press 'KÖP' to buy a product
	And I press 'Fortsätt handla' to keep buying
	And I press 'KÖP' to buy a product again
	And I press 'Gå vidare' to proceed to cart
	Then I get to the whole Klarna flow until the succeed page