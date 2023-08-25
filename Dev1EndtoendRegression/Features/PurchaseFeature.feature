@event
Feature: Purchase Flow
An end-to-end or regression test for purchasing an event in dev1

Scenario: Buying an event ticket WITH autoseating
	Given I am in dev
	And I press the menu 'MATCHER'
	When I press the button 'KÖP BILJETT'
	And I select a ticket type by pressing the button '+' once for one ticket
	And I press the button 'HITTA 1 BILJETT(ER)' to find the seats
	And press the button 'GÅ VIDARE' to the cart
	Then I get to the whole Klarna flow until the succeed page

Scenario: Buying an event ticket WITHOUT autoseating
	Given I am in dev
	And I press the menu 'MATCHER'
	When I press the button 'KÖP BILJETT'
	And I select a ticket type by pressing the button '+' once for one ticket
	And I press the button 'HITTA 1 BILJETT(ER)' to find the seats
	And press the one section on the map
	And press the one seat on the map
	And press the button 'GÅ VIDARE' to the cart
	Then I get to the whole Klarna flow until the succeed page

Scenario: Buying a season ticket WITH autoseating
	Given I am in dev
	And I press the menu 'SÄSONGER'
	When I press the button 'KÖP BILJETT'
	And I select a ticket type by pressing the button '+' once for one ticket
	And I press the button 'HITTA 1 BILJETT(ER)' to find the seats
	And press the button 'GÅ VIDARE' to the cart
	Then I get to the whole Klarna flow until the succeed page

Scenario: Buying a season ticket WITHOUT autoseating
	Given I am in dev
	And I press the menu 'SÄSONGER'
	When I press the button 'KÖP BILJETT'
	And I select a ticket type by pressing the button '+' once for one ticket
	And I press the button 'HITTA 1 BILJETT(ER)' to find the seats
	And press the one section on the map
	And press the button to select a seat
	And press the button 'GÅ VIDARE' to the cart
	Then I get to the whole Klarna flow until the succeed page

Scenario: Buying a package ticket WITH autoseating
	Given I am in dev
	And I press the menu 'MATCHER'
	When I press the button 'KÖP BILJETT'
	And I select a ticket type by pressing the button '+' once for one ticket
	And I press the button 'HITTA 1 BILJETT(ER)' to find the seats
	And press the button 'GÅ VIDARE' to the cart
	Then I get to the whole Klarna flow until the succeed page

Scenario: Buying a package ticket WITHOUT autoseating
	Given I am in dev
	And I press the menu 'MATCHER'
	When I press the button 'KÖP BILJETT'
	And I select a ticket type by pressing the button '+' once for one ticket
	And I press the button 'HITTA 1 BILJETT(ER)' to find the seats
	And press the one section on the map
	And press the one seat on the map
	And press the button 'GÅ VIDARE' to the cart
	Then I get to the whole Klarna flow until the succeed page


