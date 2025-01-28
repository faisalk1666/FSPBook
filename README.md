# Faisal's Inputs

This project demonstrates a simple implementation of a social network platform, FSPBook. The scenario tasks were designed to simulate real-world coding challenges and evaluate approaches to problem-solving, coding practices, and the ability to present and discuss solutions.

The tasks completed here address key aspects of application development, including working with data, integrating external APIs, creating dynamic user interfaces, and writing unit tests. The project uses .NET 6, MVC, and Bootstrap for styling.

## Completed Tasks

### 1. Displaying Posts on the Homepage
- **Overview**: Posts are displayed in reverse chronological order, showing the author's name, post date and time, and content.
- **Features**: 
  - Implemented pagination to show 5 posts at a time, with a "Load More" option for seamless navigation.

### 2. Adding a Technology News Feed
- **Overview**: Integrated a sidebar news feed using data fetched from [The News API](https://www.thenewsapi.com/).
- **Features**:
  - Displays the 3 most recent technology top news.
  - Shown only 3 and used the top endpoint because only this is included in free plan. 
  - Uses an `HttpClient` to fetch data and handles API errors gracefully.

### 3. Creating a Profile Page
- **Overview**: Designed a profile page to display user information (name, job title) and a feed of their latest posts in reverse chronological order.
- **Features**:
  - Hyperlinks on author names in the homepage posts lead to the appropriate profile page.
  - Posts on the profile page include timestamps for clarity.

### 4. Unit Testing
- **Overview**: Added unit tests to validate only Homepage logic

## Key Considerations and Approach

1. **Why I Chose MVC**: 
   - Separation of Concerns: MVC separates application logic into three interconnected components.
   - Scalability: MVC provides a clear structure that supports scaling the application by adding more features without overwhelming any single layer.
   - Familiarity: I am more familiar with the MVC pattern compared to Razor Pages and to give my best into this task.

2. **User Experience**:
   - Pagination and a clear layout improve usability on the homepage.
   - Minimal and responsive design using Bootstrap ensures accessibility across devices.

4. **Separation of Concerns**: 
   - Services (e.g., `NewsService`) handle external API calls and encapsulate logic for data fetching and error management.
   - Razor Views and controllers are focused on UI-related logic, keeping the project modular and maintainable.
