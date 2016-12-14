# Weather Test

Add unit testing around the PostToApis method, to achieve this I would create an interface for the HttpClient so I could inject that in using a Moq instance.

I think the way Im pushing in the Api Services but then creating a new apiservice list to retrieve the results needs revisiting, I didnt have time to create a generic injection method to populate the original object. Another way would be to create ApiRequest and Response objects. 

The UI isnt very pretty code, but serves its purpose. 

Also there are Url strings which needs to be relocated to the app settings