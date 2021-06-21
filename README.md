# Demo 
A demo app in Xamarin.Forms that searches and shows GitHub users. 
  
## Target platforms 
The focus has been iOS but all functionality should work on Android. 

## Development tools
Visual Studio for Mac together with MFractor as IDE and Postman to test REST APIs.
  
## Features 
Use GitHub's public REST API to search for GitHub users. To narrow the scope of the API the app searches for a search string is contained in either the user's email, real name or username.  
  
## Architectural decisions 
- MVVM.  
- Dependency injection and constructor injection with MS .NET Extensions. 
- Basic MVVM navigation main navigation page. 
- Simple Alert service to be able to show alerts from view models. 
- Folder structure with feature folders instead of object folders (such as ViewModels, Models etc). All files that are only used in a specific feature are grouped together. This makes it easier to find files when you are working with the project and prevents folders from containing too many files. 
- To keep the scope at reasonable level no logging and only basic error handling is implemented. 
- Using FontAwesome for icons.
 
## TODO 
It was planned to add a page to see all the detailed information provided in REST API response. A little boiler plate exist in the code together with a few TODO:s.
I would have liked to add more static resources for the XAML elements. 
