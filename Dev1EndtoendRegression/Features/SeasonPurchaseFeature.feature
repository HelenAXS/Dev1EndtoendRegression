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
	And write my e-mail
	And write my post
	And press the button 'BETALA KÖP' to continue Klarna checkout
	And press the button 'FORTSÄTT MED BANKID' to finish the purchase
	And press the button 'BETALA MED K.' to go further
	And press the button 'VÄLJ SNABBARE BETALNING' do choose the faster payment method
	Then I get to the success page 'https://web4.1.dev.tt.eu.axs.com/Checkout/KlarnaSuccess/ ...'
