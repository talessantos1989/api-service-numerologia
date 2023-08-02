# api-service-numerologia

![image](https://github.com/talessantos1989/api-service-numerologia/assets/19821533/2f654eee-e8f4-419a-a113-4cebef790f67)
The application was developed using C# and .NET Core. The project encompasses a robust WebAPI, exposing method endpoints that orchestrate complex calculations and send the results to clients via email.

This project follows a three-layer architecture:

Repository Layer: This layer is tasked with interacting with the database. It updates the client's status by setting the "sent" flag to true as soon as the numerology chart is sent.

Service Layer: Acting as the behind-the-scenes engine, this service takes on the responsibility of querying the database and identifying pending maps to be calculated through a 'false' flag. When an unprocessed map is identified, the service invokes the API, providing the client's data for analysis. Upon receiving the result, the service converts it into a PDF file, sending it to the client before initiating an update request with enviado = true.

WebAPI Layer: This component acts as the primary interface, receiving data from the service layer. It then executes 18 distinct calculations, each adapted to its specific set of rules, resulting in the generation of a PDF file. This resultant PDF is subsequently transmitted back to the service layer, which takes on the responsibility of orchestrating the email delivery process.
