# Leetcode-TopKFrequentNumbers-CS
A solution for LeetCode "Top K Frequent Elements" in C#

## Explanation
In this problem you're asked to return the top K frequenet elements in an array. This means an array of the top k elements in the array. For example in an array of `[2,2,2, 1,1, 0]` and a k value of 2. You would return `[2,1]` or `[1,2]` the order doesn't matter.

1. Create a frequency map of each number and the times it occurs.
2. Convert that frequency map into a PriorityQueue
3. Iterate over the priority queue until you've dequeued k elements into the result array and return it

**Leetcode Stats**

Runtime: 273 ms, faster than 13.79% of C# online submissions for Top K Frequent Elements.

Memory Usage: 44.3 MB, less than 89.62% of C# online submissions for Top K Frequent Elements.

## Solution
```cs
public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var freqMap = new Dictionary<int,int>();
        
        // Fill a frequency map
        foreach (var num in nums) {
            if (freqMap.ContainsKey(num)) {
                freqMap[num]++;
            } else {
                freqMap.Add(num, 1);
            }
        }
        
        // Create a Priority Queue
        var pqueue = new PriorityQueue<int,int>();
        
        // Fill the Priority Queue
        foreach (var item in freqMap) {
            // PriorityQueue.Dequeue returns lowest priority first so we add our most frequent as a negative value to get the behavior we want
            pqueue.Enqueue(item.Key, -item.Value);
        }
        
        // Add k items from Priority Queue into the Result
        var result = new int[k];
        for (int i = 0; i < k; i++) {
            result[i] = pqueue.Dequeue();
        }        
        
        return result;
    }
}
```
