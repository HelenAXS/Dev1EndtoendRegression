@pickreservation
Feature: Pick up Reservation
An end-to-end or regression test for picking up a reservation in dev1

Scenario: Pick up a Reservation in my account
	Given I am in dev
	And I press the menu 'LOGGA IN'
	When I write the e-mail for my login
	And I write the password for my login
	And I press the button "LOGGA IN" to confirm
	And I get to the main account page
	And I press the button "Reservationer" to get to the reservation page
	And press the button "Hämta Reservation" to pick up the reservation order
	And confirm the picking to get to the cart
	Then I get to the whole Klarna flow until the succeed page
