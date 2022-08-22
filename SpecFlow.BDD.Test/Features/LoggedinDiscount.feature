Feature: Loogged in users has a discount
	As a user
	I want to have a 5% discount when I am  logged in 

@mytag
Scenario: Guest users should pay full price 
	Given a user that is not logged in
	And an empty basket 
	When a t-shirt that costs 50 $ is added to basket 
	Then the basket value is 50$
	
	
Scenario: Logged in user should have 5% discount 
	Given a user that is logged in
	And an empty basket 
	When a t-shirt that costs 100 $ is added to basket 
	Then the basket value is 95$
	