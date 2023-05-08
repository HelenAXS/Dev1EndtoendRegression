@season
Feature: Season Purchase Flow
An end-to-end or regression test for purchasing an event in dev1

Scenario: Buying a season ticket
	Given I am in dev
	And I press the menu 'SÄSONGER'
	When I press the button 'KÖP BILJETT'
	And I select a ticket type by pressing the button '+' once for one ticket
	And I press the button 'HITTA 1 BILJETT(ER)' to find the seats
	And press the button 'GÅ VIDARE' to the cart
	Then I get to the whole Klarna flow until the succeed page
