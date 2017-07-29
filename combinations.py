#!/usr/bin/env python3

def printCombinations(inString, outString):
    for index, char in enumerate(inString):
        print(outString + char) # print generated combination
        if index != len(inString) - 1:
            # start the inString at i + 1 to not generate illegal values
            printCombinations(inString[index + 1:], outString + char)

def printCombinationsO(inString, outString):
    for index, char in enumerate(inString):
        print outString + char
        printCombinationsO(inString[index + 1:], outString + char)

"""
def printCombinationsD(inString, outString, start, level):
    for i in range(start, len(inString)): # index = 0 -> inString.length
        outString[level] = inString[i]
        print temp
        printCombinationsD(inString, temp, start+1, level+1)
        """

if __name__ == "__main__":

    printCombinationsO("abcd", "")
