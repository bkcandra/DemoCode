# MDwapi

HOW TO START
1.	To start please download and compile MyDeal Challenge solution from this link
https://github.com/bkcandra/MDwapi 

2.	(OPTIONAL)  Compile & build WebAPI (MDChall.WebApi),
    To make things easier, WebApi has been published to https://mdwapi.azurewebsites.net/ and by default web application has been 
    configured to consume this api. 

    In case you wanted to run the Web API locally, you might have to reconfigure API url, to do this navigate to 
    MDChall.Core > SystemConstants  and change the value of MDAPIServer to new url;

3.	Compile & Build Web Application (MDChall.Web)
4.	Have fun 😊

HOW MDChall.Web WORKS	
1.	Depending on API status you may see some records on index page. You can reset this  records by following step 2.
2.	Select a text file and click Process, the app will try to contact the API and upload file’s content to the API. In return you will get processed records displayed on index page
3.	Try to search using the earch text field on top right section of the page. Minimum of 3 letters is required to search the list for matched query, else the application will displaying all passenger records.
4.	You can click export to download a text file containing matched passenger records, to export the full list, clear the search field and click export.

