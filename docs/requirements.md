# Project Goals and Requirements

This document covers the behaviors and features of the software that are expected to be present in order for the software to be complete and to fulfill its purpose. It is mostly intended to help guide contributors working on the technical details of the software.

## Motivation

In other words, why are we doing this?

- Current practice for score keeping is to use triplicate sheets. These sheets are expensive and allow only limited redistribution of results. A digital system can save money and reduce waste.
- Score sheets are unguided, and inexperienced score keepers can introduce accidental errors into a score sheet or make it difficult to read. A digital interface can provide more guidance to a score keeper and help them fall into the "pit of success" while minimizing any errors.
- In large tournaments there are lots of quizzes going on and people rushing to and fro to get to their rounds on time. This inevitably leads to a couple score sheets getting misplaced or lost. A digital system ensures that scores are recorded _during_ the round and saved in a central location without getting lost.
- Tournaments taking place on large campuses can experience delays in getting scores due to sheer walking/running distance required to bring score sheets from quizmasters to the stats office. A digital system can transfer results over the Internet much more quickly with less energy.
- Typing in numbers from score sheets, summing up scores, creating pivot tables, and general computation are things that computers are really good at doing accurately and quickly. As heroic as the stats team often is, it is still a lot of work to keep up with scores. This is true at large tournaments with many quizzes, and at small quizzes with only one person doing stats (and often doing double-duty). A digital system will allow us to take advantage of modern computing to reduce the amount of manual work required and make it even easier to run a quiz meet.
- Today's quizzers were born in a truly digital age and are often referred to as "digital natives". Manual pen-and-paper tracking is not broken, but if we invest our time and skills into a quality digital system, it will contribute to an impression on kids that Bible quizzing is something actually worth investing in.

## General requirements

The rules followed and enforced by the software must be compliant with, and informed by, the [Official Rules & Guidelines].

### Availability

- The software should be provided as an online service that is accessible from any location with an Internet connection. An always-available online service is easy for non-technical users to access and doesn't require any installation to set up in preparation for a tournament.
- The software must be usable from a wide range of devices and platforms, including laptop computers and smartphones.
    - We should have low system demands so that even older devices can use the system successfully.
- In the event that an Internet connection is not available, it should be possible to self-host the software on a Local Area Connection (LAN).
    - It should be able to run on any ordinary Windows or macOS laptop without lots of setup. Bonus points if it can be run off of a flash drive.

## Primary features

### Tournament preparation

Provide an interface that allows leaders preparing for a tournament to pre-populate the system with the quizzers and rounds that will be quizzed during the tournament. This feature not only streamlines the score keeping process for whoever might be keeping score, but also can serve as an aid for planning the tournament itself.

- Access to the preparation interface is protected by user login. Users are granted access to this interface via individual user accounts.
- Before any new information may be entered, the user must first create a new _tournament_, where all data entered will be stored for the event the user wants to run.
- Tournaments must have a start and end date.
- Tournaments must have a location.
- Quizzers may be added to a tournament and organized into _teams_.
- Quizzers must have a name.
- Quizzers may optionally have a division.

#### Divisions

- Users may add one or more _divisions_ to a tournament. A division may be created from a predefined list, or be created from scratch.
    - Predefined divisions include a list of divisions that are commonly used at quizzing events, such as STV, YTV, STR, YTR, etc.

#### Teams

- Teams must have a division.
- Teams may optionally have a church.
- Teams may optionally have a display name to help visually distinguish between multiple teams from the same church in the same division.
- Teams must have at least two quizzers assigned to them.
- Teams not meeting these requirements can be saved, but will present a validation warning unless corrected.

#### Rounds

- A round may either be a _team round_ or an _individuals round_.
- A round must have a division.
- Team rounds must have exactly two teams added to it.
- Individuals rounds must have at least two quizzers.
- Only participants with a division matching the division of an individuals round may be added to that round.
- Creating a new round will automatically generate a unique passcode that grants access to record results for that round.
- The user may choose to regenerate the passcode for a quiz at any time.

### Public score board

To provide easy access to the current scores and results, the software must also provide a publicly accessible web page that allows you to view results as they come in in real time. This allows for clear and timely communication to all quizzers, coaches, and quiz masters, and is especially useful when hosting an event on a large campus where there can be considerable walking distance between rooms.

It also serves an archival purpose, as the results are not deleted after an event is over. Teams can review the scores after the event is over if they desire, or can share the pages with others.

- All data presented is continuously refreshed and updated as new data becomes available.
- Access is read-only; the data cannot be modified or added to from these interfaces.

#### Tournament list

Provide a view which allows the user to browse through past, current, and upcoming tournaments.

- Each tournament listed includes the tournament's date and location.
- Selecting an active or completed tournament takes the user to that tournament's overview page.

#### Tournament overview

Provide a view which shows a quick summary of all past, current, and upcoming rounds for a chosen tournament.

Selecting a round takes you to the round view.

#### Division overview

Provide a view which shows a quick summary of all past, current, and upcoming rounds that are part of the selected division.

Selecting a round takes you to the round view.

#### Round view

Provide a view that shows the current information and scores for a particular round across all rooms and quizzes for that round.

Selecting an individual quiz in the list takes you to the quiz view for that quiz.

#### Quiz view

Provide a view that shows the current information and scores for a particular quiz.

This view is presented as a more traditional grid, with individual columns per quizzer and one row per question. Each cell indicates the score awarded to the quizzer during that question, with small visual icons that indicate whether a prejump occurred or missed.

New updates to the round are polled by the page regularly while open, and the page is automatically populated with new changes.

### Score keeping

Provide a simple web app that, when provided with a secret code, allows one to fill in the scoring details for the round that the code is associated with.

#### Getting access

To populate the scores for a quiz, the user must first select the desired quiz. This can be done from either the public interface, or by typing in a quiz's identifier directly.

Once a quiz is selected, the user must type the passcode into a password text field for that quiz correctly in order to gain access to fill in the scores.

Only one user may have access to the score keeping area for a quiz at any given time. If another user attempts to keep score for a quiz while someone else also has the interface open, a message will be displayed preventing that user from continuing. User uniqueness must be determined by a browser cookie that cannot be spoofed or yield false positives.

#### Populating scores

Once access via passcode is granted, a new screen is displayed that allows the populating of per-question scores for the corresponding quiz.

At the top of the screen, the details of the current quiz are displayed, such as the tournament, round number, and room,

Below the round information, a form is displayed that allows the user to populate the results of the current question. The current question number is displayed at the top, with a button that advances the quiz to the next question.

Below the current question number, the names of all quizzers are displayed, including those not currently in play, along with their individual cumulative scores. If this quiz is a team round, the names of both teams are also displayed along with the current cumulative score of each team.

Next to each name is a selectable box that allows the user to assign points to the quizzer for answering the current question correctly. Only one quizzer may be awarded points at a time, and selecting another quizzer after already assigning points "moves" the assignment to the most recent selection. Quizzers not "in play" cannot be awarded points.

A separate checkbox is also present that allows the user to indicate which quizzers prejumped during this question. In an individual round, all quizzers that have been marked as prejumped, but are not awarded points, have 10 points deducted automatically after the 3rd missed prejump for the quiz.

At any time, the score keeper may tap a name listed to bring up a modal that allows you to take that quizzer in or out of play for substitutions. Quizzers that have reached 100 cumulative points are taken out of play automatically, and cannot be brought back into play.

Quizzers out of play are indicated with a slight visual distinction, and all scoring buttons are disabled for such quizzers.

Once the score keeper is satisfied with the data entered for the current question, the score keeper must click a button at the bottom of the view labelled "Next Question". This button saves the current information and advances the quiz to the next question.

Any unsaved changes so far on this screen must be persisted in local storage so that unexpected page reloads or disconnects do not cause the changes to be lost.

##### Full round view

Somewhere in the score populating interface, a button or tab is visible that allows the user to quickly switch back and forth to a page that displays all the questions so far in a single screen, which allows the score keeper to double-check things as needed and to look back on previous questions should the score keeper be asked by the quizmaster to recall something.

This view is identical to the public [quiz view](#quiz-view), with the following additions:

- Selecting a previous question allows you to "correct" incorrectly entered information should the wrong information be entered by mistake.
- A button or tab is present that allows the score keeper to quickly switch back to the current question view.

#### Completing a quiz

After the quiz is considered complete, a new view is presented that allows the score keeper to finalize the results and submit them.

The quiz is considered complete under any of the following conditions:

- The round is a team round and the team scores are not equal after 15 questions, unless the round has the "fast rounds" option set.
    - If the "fast round" option is set for the quiz's round, the round is complete as soon as it is mathematically over (one team is ahead and there are not enough remaining questions for the other team to tie before 15 questions).
- The round is an individuals round and there is a clear winner after 15 questions. A clear winner is the first quizzer to reach 100+ points, or a quizzer with a score greater than all other quizzers.

Once a quiz has been completed, the score keeper must press a button indicating that the quiz has been completed. The user is asked to confirm their choice, as the operation is final. In this submission view, a Comments text box is also displayed. The score keeper may optionally type in additional comments about the round in case advanced or unique instructions are needed to understand the quiz results.

A quiz that has been completed can no longer be added to or modified from the score keeping interface, even if the user knows the passcode.

### API

To foster a future ecosystem of websites, apps, and smart devices that streamline and improve the Bible Quizzing program, this project should be designed to be _API-first_. Providing a public API allows other developers to build their own software that uses common data from our system and extend upon it without requiring everyone to be involved.

- Since HTTP clients are widely available for many languages and frameworks, the API must be an HTTP-based API to ensure broad compatibility with whatever a third-party developer is trying to build.
- APIs that are not read-only must require some sort of authorization to prevent modifications from spam requests or bad actors.

## Unresolved questions

- Some conferences like to _bend_ conventions for their local events a little. How do we account for that, if at all?


[Official Rules & Guidelines]: https://dev.fmquizzing.net/resources/assets/pdfs/Rules-2019-7.4.19.pdf
