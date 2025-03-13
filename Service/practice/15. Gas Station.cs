public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {

        // first check to see if the sum of the gas is less than the sum of the cost
        // if so, early exit. No iteration needed
        var totalGas = gas.Sum();
        var totalCost = cost.Sum();
        if(totalGas < totalCost){
            return -1;
        }
        
        var numberOfStations = gas.Length;
        //Console.WriteLine($"Number of stations: {numberOfStations}");


        for(int i = 0; i < gas.Length; i++){
            var gasInTank = 0; // start with 0 units in the tank
            //Console.WriteLine($"Start of Cycle Index: {i}");
            var ranOutOfGas = false;

            var currentStationIndex = i;
            do {
                //Console.WriteLine($"Begin Loop - Current Station: {currentStationIndex}");
                // Add the gas at this station
                gasInTank += gas[currentStationIndex];
                //Console.WriteLine($"Added {gas[currentStationIndex]}, new tank value {gasInTank}");
                // remove the cost to get to the next station
                gasInTank -= cost[currentStationIndex];
                //Console.WriteLine($"Getting to next destination. Cost {cost[currentStationIndex]}, new tank value {gasInTank}");

                // check if we've run out of gas
                if(gasInTank < 0){ 
                    //Console.WriteLine($"Ran out of gas, try next starting point");
                    // exit the while
                    ranOutOfGas = true; 
                }


                // reset currentStationIndex
                if(currentStationIndex == numberOfStations - 1) { // end of the array
                    currentStationIndex = 0; // set the current station to the beginning
                }
                else{
                    currentStationIndex++; // otherwise increment
                }
                ////Console.WriteLine($"End Loop - Current Station: {currentStationIndex}");

            }
            while(currentStationIndex != i && !ranOutOfGas);
            

            // we made it through the entire cycle without running out of gas!
            if(!ranOutOfGas){
                return i;
            }
        }
        return -1;// tried all the cycles, but ran out of gas on each one.
    }
}