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

### Score keeping

- Provide a simple web app that, when provided with a secret code, allows one to fill in the scoring details for the round that the code is associated with.
    - The web app must cache intermediate results offline so that unexpected page reloads or disconnects do not cause all progress so far to be lost.
- Access to populating the scores for a round must be protected by a passcode.

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

#### Division overview

Provide a view which shows a quick summary of all past, current, and upcoming rounds that are part of the selected division.

#### Round view

Provide a view that shows the current information and scores for a particular round.

### API

To foster a future ecosystem of websites, apps, and smart devices that streamline and improve the Bible Quizzing program, this project should be designed to be _API-first_. Providing a public API allows other developers to build their own software that uses common data from our system and extend upon it without requiring everyone to be involved. We do not have the time and resources

- Since HTTP clients are widely available for many languages and frameworks, the API must be an HTTP-based API to ensure broad compatibility with whatever a third-party developer is trying to build.
- APIs that are not read-only must require some sort of authorization to prevent modifications from spam requests or bad actors.

## Unresolved questions

- Some conferences like to _bend_ conventions for their local events a little. How do we account for that, if at all?
- Paper score sheets allow us to also track things, such as notes about question types, jump orders, etc. How can we make sure that coaches can continue to get this type of information if they are interested in it?


[Official Rules & Guidelines]: https://dev.fmquizzing.net/resources/assets/pdfs/Rules-2019-7.4.19.pdf
