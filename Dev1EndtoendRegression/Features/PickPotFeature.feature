@pickpot
Feature: Pick up Pot
An end-to-end or regression test for picking up a pot in dev1

Scenario: Pick up a pot in my account
	Given I am in dev
	And I press the menu 'LOGGA IN'
	When I write the e-mail for my login
	And I write the password for my login
	And I press the button "LOGGA IN" to confirm
	And I get to the main account page
	And I press the button "Hämta pottbiljetter" to get to the pot page
	And I press the button "" to choose the event and get to the ticket type page
	And I select a ticket type by pressing the button '+' once for one ticket
	And I press the button 'HITTA 1 BILJETT(ER)' to get to the cart
	Then I get to the Klarna flow for free until the succeed page
