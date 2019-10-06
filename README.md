# FactoringBySubstrings
Use the numbers that make up a bigger number to factor the bigger number.

This is my attempt to beat P=NP -- trying to factor much faster than GNFS using a novel approach.

# Idea

Back in elementary school we learn "Numbers are divisible by 3 if the sum of all the individual digits is evenly divisible by 3" but then we never consider individual digits in divisiblity ever again. What if there is a more general/broad pattern using individual digits?

If we can create factors from a given number's individual digits, we can almost instantly factor it solving P=NP.


# Example

Take a basic example like 12. If we consider both positive and negative digits, it's substrings are {-1;1;-12;12;-2;2;}. Now consider the powerset (combination) of these substrings.

{...{-1,2,-12}...{1,2}...}

We can sum the members in each grouping

{...{-11}...{3}..}

To find potential factors. Here 3 is a factor!

If we can figure out the pattern of WHEN the factor occurs, we can use that placement to instantly factor the number. Research is still going into how often this strategy works and what optimizations can be made.

For example "119" has two substrings that are 1. Do we just want the distrinct substrings? Who knows.
