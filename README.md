# DarkerSmileCore
The base library to all common .Net projects. Predominantly tidy helper classes for cleaner null checking syntax. 

Mostly this includes helper extension methods. 
For the most part this core section is task agnostic and has some features that should be helpful to nearly all projects. 

Some of the Highlights:

Enumeration/List extensions:

Shuffle
GetRandomOne
GetRandomX
TakeRandomOne
TakeRandomX
   - for shuffling lists, getting random elements out of enumerations or 'Taking' random elements out of lists. 

AddUnique
  - for merging two enums but only the unique values

Clamp
ClampToList
ClampToListWrapped

  - Clamp clamps and IComparer, the othe two are for ints. Clamping to ensure a selection index does not give index out of
  bounds by either sticking to min max or looping around with a modulus. 

Reflection Extensions
   GetAllProperties
   GetPrivateProperties
   GetPublicProperties
      - returns a list of properties on an object
      
    GetValue
      - returns the value of a property based on name, such as GetValue("Health"); if used with the above can be used
      to iterate through all properties on an object. 
      
    GetValue(Expression)
      - a tpye safe version of the previous, player.GetValue(x=>x.Health) , returns the value of health. 
      
Finally some helper functions for clean code naming. Removes some of the code noise of null checks and such:

   Fire
     - on Actions and Funcs, does the null check and only invokes if not null
     
    Exists
    DoeSNotExist
    NullOrDefault
    
     - simply a null check, with the exception of null or default which is needed in some cases of generic comparisons where
     you do not know if the item can be null, instead checks to see if (using a default comparer) the element represents its own
     default state. 
     
     
      
      
      

