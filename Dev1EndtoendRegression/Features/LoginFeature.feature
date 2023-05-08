@logIn
Feature: Login
An end-to-end or regression test for login in dev1

Scenario: Login in my account
	Given I am in dev
	And I press the menu 'LOGGA IN'
	When I write the e-mail for my login
	And I write the password for my login
	And I press the button "LOGGA IN" to confirm
	Then I get to the main account page