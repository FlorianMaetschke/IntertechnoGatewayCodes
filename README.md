# CMR-500
Intertechno ITGW-433 Gateway Control Codes for CMR-500 Radio-controlled shutter switch.

Ever wanted to control your ITGW-433 Gateway with your own code? Now you can using this sweet little library.

Just add the IntertechnoGateway.cs file to your c# project and it is as easy like this to get started:

Add using:

            using Intertechno.ITGW433Gateway;
            // ...

Write code:
  
            // create gateway connection instance
            var gateway = new CMR500("192.168.1.101");  // create gateway connection instance
            // send DOWN to CMR-500 with code M1
            gateway.Send(LetterCodes.LetterM, NumberCodes.Number1,ControlCodes.ControlDown);  
