# unity-utilityai

A very basic use of Utility AI for Unity.

The concept is each AI has a brain component which you load with thoughts which are scriptable objects. Each thought is checked and returns a number from 0 - 100.

The lowest number returned is the most urgent and gets executed.

## Video Example:

[Example video](https://www.youtube.com/watch?v=iLx7c01gNRI)

## Usage

Add the AI brain to your NPC's and then create your own thoughts by extending the base thought. When a thought is weighed or executed it gets sent the gameobject of its owner, you can use this to access the information to make the decision.

When you create a new thought you need to also make a scriptable object based off it. This is what you add to your AI's brain.
Each though has a curve which allows you adjust its urgency.

## Licence

You are free to use this in any project but if you find it helpful all I ask is you pop my name in the credits. 

## Todo

Make a full example
Add better documentation
