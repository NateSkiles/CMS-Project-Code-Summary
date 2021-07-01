# C Sharp Live Project Code Summary

### Key
* [Introduction]()
* [Frontend Story]()
* [Comment Section]()
* [Skills Aquired]()


## Introduction
For two weeks, I joined a project building a content management system (CMS) for a local theatre company. The purpose of the application was to provide a platform for the theatre company to manage and showcase its services (rentals, a blog, and productions). During my time on the project, I mostly worked on build a comment section from scratch with ASP.NET MVC. 
 
 ## Frontend Story
 ### About Page
 My first story on the team was to create an about page, using a mockup and the company's current website. I used this story to become comfortable with Bootstrap 4, and produced a product that is both responsive and accurate to the design the company approved.
  
  An early roadblock for my team and me on the project involved getting images to span the whole page. This problem ended up being easy to find with Chrome Dev Tools. I discovered that our pages were inheriting margins from the website _Layout styling. Then, I  unset the margins for that class in style tags on my webpage and reset proper margins to my page in a CSS file. Which solved any cascading issues for us when implementing background images.
  
  For the ensemble portraits, I used Bootstrap's card-deck feature to create a responsive design that is aesthetically pleasing on any viewport.
 
 ## Blog Post Comment Section
 ### Getting Started
 As mentioned previously, I spent the majority of my time on the team, creating a comment section for the blog area of the website. This section is broken up chronologically, in the order in which I completed each user story.  Demonstrating the process I went through to create something from scratch in an existing codebase.
 
 ### Create Model
 For this story I was tasked with creating a model for a Comment in the blog post area. This model needed to include things like the user who wrote it, the comment itself, when it was created, and likes/dislikes. In the constructor method I set the Comment's date to the current time, so that whenever a comment is created it is timestamped. Finally, a method to find the current likes to dislikes ratio for a comment when called. This will be used later with AJAX and jQuery to create a dynamic ratio bar.
 
 ```c#
 public class Comment
     {
         // Props
         public int CommentId { get; set; }
         public ApplicationUser Author { get; set; }
         public string Message { get; set; }
         public DateTime CommentDate { get; set; }
         public int Likes { get; set; }
         public int Dislikes { get; set; }

         // Comment Constructor
         public Comment()
         {
             CommentDate = DateTime.Now;
         }

         // Return percentage of likes to total votes
         public double LikeRatio()
         {
             return Likes / (Likes + Dislikes) * 100;
         }
 ```
 
 With this model I used EntityFramework to scaffold CRUD pages. These pages gave us the basic functionailty of a comment seciton. 
 
 ### Creating Partial View
 Afer creating the model I made a partial view, to allow me to call my comment section on other web pages. More specifically, allowing me to add a comment section in multiple blog posts or different places. Below is the code used to to call my partial view. 
 
 ```html+razor
 @{ 
   Html.RenderPartial("_Comments");
 }
 ```
 
 ```html+razor

 <div class="row">
     <div class="col">
         <span class="comment-author">@item.Author</span>
         <span class="time-since">@item.TimeAgo()</span>
     </div>
 </div>

 @* Comment message body *@
 <div class="row">
     <div class="col-lg-10 mx-auto mt-2">
         <div class="commment-body">
             <p>@item.Message</p>
         </div>
     </div>
 </div>

 @* Comment like *@
 <div class="row">
     <div class="col- mx-1">
         <button class="btn btn-sm comment-upvote" id="comment-upvote" onclick=upvote(@item.CommentId)>
             <i class="fa fa-thumbs-up fa-lg text-primary"></i>
         </button>
         <label class="comment-likes" data-commentId="@item.CommentId">@item.Likes</label>
     </div>

     @* Comment Dislike *@
     <div class="col- mx-1">
         <button class="btn btn-sm comment-downvote" id="comment-downvote" onclick=downvote(@item.CommentId)>
             <i class="fa fa-thumbs-down fa-lg text-primary"></i>
         </button>
         <label class="comment-dislikes" data-commentId="@item.CommentId">@item.Dislikes</label>
     </div>
 </div>
 ```
 ### Like/Dislike Feature
 * Implementation
 -- Work In Progress --
 * Ratio Bar
 -- Work In Progress --
 ### Delete Comment & Comment Moderator
  -- Work In Progress --
 ### Link Comment To Blog Post 
  -- Work In Progress --
 ## Skills Aquired
  -- Work In Progress --
 
