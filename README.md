# PowerplantChallenge

## How to build

To build the application, run the command `dotnet run` on the project folder (powerplant-coding-challenge\PowerplantChallenge). This will launch the API on port `8888`

## Usage

To call the API, make a POST request to endpoint `https://localhost:8888/productionplan` and add the json structure in the body of the request.

## Description

Implementation was not finished, but covers the example payloads. The implementation does not cover the optimal case of most of the examples, but tries to cover the total load as best as it can, and thus in some cases it can cause Overload (generating more power than it should). The overload approach was preferred to ensure the total load would be achieved, instead of risking generating less power than expected.

## Next steps

### Improving implementation

Full implementation of Unit commitment problem would be needed to ensure optimal load distribution. More time would be necessary to better adapt this algorithm to a more robust one.

### Docker

A Dockerfile has been created but there was no time to finish and test properly. 

### CO2

CO2 emissions were not taken into consideration for this implementation