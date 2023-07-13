# Lincoln Investment Software Engineering Homework

Please complete the three exercises.  There is no time limit but we estimate that these exercises can be completed within 1-2 hours.  We will be evaluating your code on correctness, completeness, and maintainability.  

The solution requires [Visual Studio 2022](https://www.visualstudio.com/downloads/) (Community Edition is free) with MS Test enabled.

Exercises 1 and 2 have unit tests which currently fail.  You must make the tests pass without changing the test code or test data.  Exercise 3 involves making small changes to a WebApp.  Directions for these exercises can be found below.

Download the code from this repository, either by cloning or downloading it as a zip file.  When finished, please create a new public repository (e.g. on your own GitHub, GitLab, BitBucket, etc. account), push your code to it, and provide a message, including your repository URL, to your Lincoln contact stating that it is ready for review.  We do this instead of using forks because candidates can see each other's forks, so **please do not fork this repo**.  If you prefer not to use a public repository service like GitHub to host your completed homework, please provide access to your code by some other means and send us a URL.  We cannot accept submissions via email.

**Thank you for very much for taking the time to complete this homework assignment.** 

## 1. Descriptive Statistics

 A local charity needs to analyze data about contributions. Write a library which accepts a semicolon-delimited collection of human-keyed monetary contributions as a string (e.g. `“5 ; $ 123.42; $5,401.56”`) and returns three statistics about them: average, median, and range all rounded to two decimal places.

If no valid contributions are entered, the library should simply return 0 for all three metrics.

```
Example input:
$2,550.50; 1000; $6345.45; 7,565.65;12,568.68;$6356.56;2550.5; 500.45

Example output:
Average: 4929.72
Median: 4447.98
Range: 12068.23
```

## 2. Commissions
A financial firm pays commissions to advisors based on seniority and account fees. An account fee is the present value of the account multiplied by [basis points](http://www.investopedia.com/terms/b/basispoint.asp) in a tiered structure:

* less than $50,000 = 5 bps
* greater than or equal to $50,000 = 6 bps
* greater than or equal to $100,000 = 7 bps

An advisor’s commission is a percentage of the account fee based on their seniority:

* Senior = 100%
* Experienced = 50%
* Junior = 25%

Build a calculator which reads data from a JSON string and produces a commission report: each rep name and their commission rounded to two decimal places. 

Important tips:

* It is safe to assume that Advisor names are globally unique
* We expect there to be **thousands** of advisors and accounts in the input data, so be mindful of potential performance issues.
* An advisor who does not have any accounts should have a commission of 0.
* Other than the unit tests and test data, any code can be modified.

```
Example input:
{
  "advisors": [
    {
      "name": "Joe",
      "level": "Junior"
    },
    {
      "name": "Karen",
      "level": "Senior"
    }
  ],
  "accounts": [
    {
      "advisor": "Joe",
      "presentValue": 65000
    },
    {
      "advisor": "Karen",
      "presentValue": 49000
    }
  ]
}

Example output:
Joe: 9.75
Karen: 24.50
```

## 3. WebApp
* It looks like there's no privacy statement in this WebApp.  Please add one so that when users browse to /Home/Privacy they see the following message: `We take your privacy very seriously.`
  * This message will not change often.
  * When this message changes we can wait for the next scheduled release before deploying the change.
                
* On the Home page, in the designated DateTime area, we'd like to display the current date and time in ISO-8601 format as well as a conditional link to `/Other/EvenMinute`:
  * "Current date and time" is valid as long as it is within 30 seconds of the time when the page has finished rendering in the browser.
  * If the minute is odd, do not display the link.
  * If the minute is even:
    * Display a link to `Other/EvenMinute` below the date and time.
    * The displayed text should be `Even Minute`
    * Clicking this link should open a new browser tab.
  * Once the page has finished loading there is nothing more to do.  There is no need to update the page when the minute changes.
