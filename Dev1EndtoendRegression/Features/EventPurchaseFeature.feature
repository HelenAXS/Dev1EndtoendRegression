Feature: Event Purchase Flow
An end-to-end or regression test for purchasing an event in dev1


Scenario: Buying an event
	Given I am in dev
	And I press the menu 'MATCHER'
	When I press the button 'KÖP BILJETT'
	And I select a ticket type by pressing the button '+' once for one ticket
	And I press the button 'HITTA 1 BILJETT(ER)
	And press the button 'GÅ VIDARE' to the cart
	And write my e-mail
	And write my post
	And press the button 'BETALA KÖP' to continue Klarna checkout
	And press the button 'BETALA {0} KR IDAG MED K.' to finish the purchase
	Then I get to the success page 'https://web4.1.dev.tt.eu.axs.com/Checkout/KlarnaSuccess/ ...'
