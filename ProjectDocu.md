## JoHoot project documentation.

### Solution structure

1. Johoot
	- blazor frontend application
1. Johoot.ComponentsLibrary
	- razor libraries
1. Johoot.Api
	- separated API for project
	- only the most important things show publicly
1. Johoot.Application
	- application logic and more complicated operations
1. Johoot.Domain
	- interfaces
	- Domain models / entities
	- enums
	- exceptions
	- specifications
1. Johoot.Infrastructure
	- DB
	- DB access
	- DB configuration
	- Repositories
1. Johoot.Share
	- shared models (instead using a lot of mappers)
