@potAndProduct
Feature: Pot and Produkt Purchase Flow
An end-to-end or regression test for purchasing an event in dev1


Scenario: Buying a pot
	Given I am in dev
	And I press menu 'PRODUKTER'
	And I press the option 'POT'
	And I press the button '+'
	When I press 'KÖP' to buy a pot
	And I press 'Fortsätt handla' to keep buying
	And I press the button '+' again
	And I press 'KÖP' to buy a pot again
	And I press 'Gå vidare' to proceed to cart
	Then I get to the whole Klarna flow until the succeed page

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

Scenario: Buying a product
	Given I am in dev
	And I press the menu 'PRODUKTER' for product
	And I press the button '+' for product
	When I press 'KÖP' to buy a product
	And I press 'Fortsätt handla' to keep buying for product
	And I press the button '+' for product again
	And I press 'KÖP' to buy a product again
	And I press 'Gå vidare' to proceed to cart for product
	Then I get to the whole Klarna flow until the succeed page