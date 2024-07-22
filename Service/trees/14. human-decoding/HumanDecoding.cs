public class HumanDecoding{
    /*
        - Convert Seconds into Days, Hours, Minutes, and Seconds
        - If it exists, add the word Day, and if day is greater than 1, Days
        - If it exists, add the word Hour and if hour is greater than 1, Hours
        - If it exists, add the word Minute and if minute is greater than 1, Minutes
        - Comma Separate the words
    */

    public string HumanDecode(int numSeconds){
        var secondsPerMinute = 60;
        var minutesPerHour = 60;
        var hoursPerDay = 24;

        var secondsPerDay = secondsPerMinute * minutesPerHour * hoursPerDay;
        var secondsPerHour = secondsPerMinute * minutesPerHour;

        // Calculate Number of Days
        var days = numSeconds / secondsPerDay;

        // Calculate Number of Remaining Hours
        var hours = (numSeconds % secondsPerDay) / secondsPerHour;

        // Calculate Number of Remaining Minutes
        var minutes = (numSeconds % secondsPerHour) / secondsPerMinute;

        // Calculate Number of Remaining 
        var seconds = numSeconds % secondsPerMinute;   


        var daysResult = days > 0 ? $"{days} Day{(days > 1 ? "s" : "")}" : "";
        var hoursResult = hours > 0 ? $"{hours} Hour{(hours > 1 ? "s" : "")}" : "";
        var minutesResult = minutes > 0 ? $"{minutes} Minute{(minutes > 1 ? "s" : "")}" : "";
        var secondsResult = seconds > 0 ? $"{seconds} Second{(seconds > 1 ? "s" : "")}" : "";
        var output = new List<string>();
        if(daysResult != "") output.Add(daysResult);
        if(hoursResult != "") output.Add(hoursResult);
        if(minutesResult != "") output.Add(minutesResult);
        if(secondsResult != "") output.Add(secondsResult);


        if(output.Count == 1){
            return output[0];
        }
        var lastElement = output[output.Count - 1];
        output.RemoveAt(output.Count - 1);
        return string.Join(", ", output) + ", and " + lastElement;

    }
}