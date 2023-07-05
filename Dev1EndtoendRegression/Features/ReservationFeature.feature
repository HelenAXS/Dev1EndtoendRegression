@reservation
Feature: Reservation Flow
An end-to-end or regression test for reservation in dev1

Scenario: Reservation of an event, a season, a product and a pot WITH autoseating
	Given I am in dev
	And I press the menu 'MATCHER'
	When I press the button 'KÖP BILJETT'
	And I select a ticket type by pressing the button '+' once for one ticket
	And I press the button 'HITTA 1 BILJETT(ER)' to find the seats
	And press the button 'GÅ VIDARE' to the cart
	
	And I press the menu 'SÄSONGER' again
	And I press the button 'KÖP BILJETT' again
	And I select a ticket type by pressing the button '+' once for one ticket again
	And I press the button 'HITTA 1 BILJETT(ER)' to find the seats again
	And press the button 'GÅ VIDARE' to the cart again

	And I press the menu 'PRODUKTER' one more time
	And I press 'KÖP' to buy a product
	And I press 'Fortsätt handla' to keep buying

	And I press 'KÖP' to buy the pot this time
	And I press 'Gå vidare' to proceed to cart

	And in the cart I press the button "Reservera" to reserve the purchase
	And I write the e-mail for login
	And I write the password for login
	And I press "Logga In" to confirm
	And I checkbox to accept the terms
	And I get to the page with my information and press the button to confirm
	
	Then I get to the success page of the reservation

	Scenario: Reservation of an event, a season, a product and a pot WITHOUT autoseating
	Given I am in dev
	And I press the menu 'MATCHER'
	When I press the button 'KÖP BILJETT'
	And I select a ticket type by pressing the button '+' once for one ticket
	And I press the button 'HITTA 1 BILJETT(ER)' to find the seats
	And press the one section on the map
	And press the one seat on the map
	And press the button 'GÅ VIDARE' to the cart
	
	And I press the menu 'SÄSONGER' again
	And I press the button 'KÖP BILJETT' again
	And I select a ticket type by pressing the button '+' once for one ticket again
	And I press the button 'HITTA 1 BILJETT(ER)' to find the seats again
	And press the one section on the map
	And press the one seat on the map
	And press the button 'GÅ VIDARE' to the cart again

	And I press the menu 'PRODUKTER' one more time
	And I press 'KÖP' to buy a product
	And I press 'Fortsätt handla' to keep buying

	And I press 'KÖP' to buy the pot this time
	And I press 'Gå vidare' to proceed to cart

	And in the cart I press the button "Reservera" to reserve the purchase
	And I write the e-mail for login
	And I write the password for login
	And I press "Logga In" to confirm
	And I checkbox to accept the terms
	And I get to the page with my information and press the button to confirm
	
	Then I get to the success page of the reservation