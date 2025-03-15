public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int totalGas = 0;
        int totalCost = 0;
        int currentGas = 0;
        int startStation = 0;

        for (int i = 0; i < gas.Length; i++) {
            totalGas += gas[i];
            totalCost += cost[i];
            currentGas += gas[i] - cost[i];

            // If currentGas is negative, reset the start station to the next station
            if (currentGas < 0) {
                startStation = i + 1;
                currentGas = 0;
            }
        }

        // If total gas is less than total cost, it's not possible to complete the circuit
        if (totalGas < totalCost) {
            return -1;
        }

        return startStation;
    }
}