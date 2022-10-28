# CLI Version

Please read the story and do your implementation.

## Story 1

As a customer, I would like to give my car to a parking boy so that he can help me park a car to the parking lot.

AC1: The parking boy can park a car into the parking lot and returns a parking ticket. The customer can give the parking ticket back to the parking boy to fetch the car.

AC2: The parking boy can park multiple cars into on parking lot. And can fetch right car using correspond ticket.

AC3: If the customer gives a wrong ticket (the parking boy does not provide the ticket) or does not give a ticket. Then no car should be fetched.

AC4: If the customer gives a ticket that has already been used. Then no car should be fetched.

AC5: The parking lot has a capacity (the default capacity of a parking lot is 10). If there is no position, then the user cannot park the car into it. Thus (s)he will not get any ticket.

> There are some cases which are not a requirement but may happen technically 
>
> * Passing a parked car to a parking boy.
> * Passing a `null` car to a parking boy.

## Story 2

As a customer, I would like to get some response message from the parking boy when I cannot fetch the car. So that I can know what happens.

AC1: When the customer gives a wrong ticket (the parking boy does not provide the ticket / the ticket has been used). Then no car should be fetched. If I query the error message, I can get an "Unrecognized parking ticket.".

AC2: When the customer does not provide a ticket when fetching a  car. The error message should be "Please provide your parking ticket."

AC3: When the parking boy attempt to park a car into a parking lot without a position. The error message should be "Not enough position."

## Story 3

As a parking lots service manager, I would like to have a parking boy parking cars to multiple parking lots. So that I can provide more parking positions.

AC1. The parking boy is not that clever, and he will always park cars sequentially (suppose that there are two parking lots managed by the parking boy. The parking boy will park cars to the second parking lot when the first parking lot is full).

AC2: All the requirement in *Story 1* and *Story 2* **MUST** be satisfied.

## Story 4

As a parking lots service manager. I would like to have another kind of parking boy to help me parking cars to multiple parking lots. So that the parking positions can be better used.

The new kind of parking boy is called **SMART PARKING BOY**.

AC1. The smart parking boy will always park cars to the parking lot which contains more empty positions.

AC2: All the requirement in *Story 1* and *Story 2* **MUST** be satisfied.
