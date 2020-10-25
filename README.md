# FlightEngineer
This project applies aerodynamic principles to create a modular, physics based aircraft controller for Unity, allowing the user to build fully customisable plane specifications.

Included in the project is a single scene containing a basic aeroplane model to demonstrate how the controller is used. For each component of the aircraft, there is an applied
script to control that component. The list of components and the associated scripts are as follows (Component: Scripts):
     - Propeller: PistonEngine, Propeller
     - LeftWing: HorizontalWing
     - RightWing: HorizontalWing
     - LeftAileron: ControlSurface
     - RightAileron: ControlSurface
     - LeftFlap: ControlSurface
     - RightFlap: ControlSurface
     - Elevator: ControlSurface
     - Rudder: ControlSurface
     
Each component also requires a specification to define the performance of that part. This allows for a completely modular system where a plane could be modelled using any
combination of parts.
