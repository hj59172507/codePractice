"""
Number of Good Ways to Split a String

You are given a string s, a split is called good if you can split s into 2 non-empty strings p and q where its concatenation is equal to s and the number of distinct letters in p and q are the same.

Return the number of good splits you can make in s.

Example 1:

Input: s = "aacaba"
Output: 2
Explanation: There are 5 ways to split "aacaba" and 2 of them are good.
("a", "acaba") Left string and right string contains 1 and 3 different letters respectively.
("aa", "caba") Left string and right string contains 1 and 3 different letters respectively.
("aac", "aba") Left string and right string contains 2 and 2 different letters respectively (good split).
("aaca", "ba") Left string and right string contains 2 and 2 different letters respectively (good split).
("aacab", "a") Left string and right string contains 3 and 1 different letters respectively.
Example 2:

Input: s = "abcd"
Output: 1
Explanation: Split the string as follows ("ab", "cd").
Example 3:

Input: s = "aaaaa"
Output: 4
Explanation: All possible splits are good.
Example 4:

Input: s = "acbadbaada"
Output: 2

Constraints:

s contains only lowercase English letters.
1 <= s.length <= 10^5

Sol
Time O(n)
Space O(1)
Iterate over i from 0 to len(s), let p, q be dictionary store count of letter in s when we split s at i,
if number of keys of p == q, then increment result
"""
import collections


class Solution:
    def numSplits(self, s: str) -> int:
        res = 0
        p, q = collections.defaultdict(int), collections.defaultdict(int)
        for i in s:
            q[i] += 1
        for i in range(len(s)):
            c = s[i]
            q[c] -= 1
            if q[c] == 0:
                del q[c]
            p[c] += 1
            if len(p) == len(q):
                res += 1
        return res