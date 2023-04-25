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

	And write my e-mail
	And write my post
	And press the button 'BETALA KÖP' to continue Klarna checkout
	And press the button 'FORTSÄTT MED BANKID' to finish the purchase
	And press the button 'BETALA MED K.' to go further
	And press the button 'VÄLJ SNABBARE BETALNING' do choose the faster payment method
	Then I get to the success page 'https://web4.1.dev.tt.eu.axs.com/Checkout/KlarnaSuccess/ ...'