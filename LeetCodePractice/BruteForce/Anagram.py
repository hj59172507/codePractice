"""
1347. Minimum Number of Steps to Make Two Strings Anagram

Given two equal-size strings s and t. In one step you can choose any character of t and replace it with another character.

Return the minimum number of steps to make t an anagram of s.

An Anagram of a string is a string that contains the same characters with a different (or the same) ordering.

Example 1:

Input: s = "bab", t = "aba"
Output: 1
Explanation: Replace the first 'a' in t with b, t = "bba" which is anagram of s.
Example 2:

Input: s = "leetcode", t = "practice"
Output: 5
Explanation: Replace 'p', 'r', 'a', 'i' and 'c' from t with proper characters to make t anagram of s.
Example 3:

Input: s = "anagram", t = "mangaar"
Output: 0
Explanation: "anagram" and "mangaar" are anagrams.
Example 4:

Input: s = "xxyyzz", t = "xxyyzz"
Output: 0
Example 5:

Input: s = "friend", t = "family"
Output: 4

Constraints:

1 <= s.length <= 50000
s.length == t.length
s and t contain lower-case English letters only.

Sol
Time O(n)
Space O(n)
Count the occurrence of each char in s, and t.
Subtract s from t, sum up the diff and ignore negatives.
"""
import collections


class Solution:
    def minSteps(self, s: str, t: str) -> int:
        sd = {}
        td = {}
        res = 0
        for i in range(len(s)):
            if s[i] in sd:
                sd[s[i]] += 1
            else:
                sd[s[i]] = 1
            if t[i] in td:
                td[t[i]] += 1
            else:
                td[t[i]] = 1
        for k in sd.keys():
            if k in td:
                res += max(sd[k] - td[k], 0)
            else:
                res += sd[k]
        return res


s = Solution()
si = "friend"
ti = "family"
print(s.minSteps(si, ti))
# or short way
c1, c2 = map(collections.Counter, (si, ti))
print(sum((c1-c2).values()))
