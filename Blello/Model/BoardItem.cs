using System;
using System.Collections.Generic;

namespace Blello.Model
{
    public class BoardItem
    {
        public int BoardId { get; set; }
        public string Content { get; set; }
        public string ItemID { get; set; }

        public BoardItem()
        {
            ItemID = Math.Abs(Guid.NewGuid().GetHashCode()).ToString();
        }

        public override string ToString()
        {
            return Content;
        }

        public static List<string> SampleDataHeaders()
        {
            return new List<string>()
            {
                "Tasks to Do",
                "Completed Tasks",
                "Topics/Concepts to Revise",
                "Topics/Concepts to Learn",
                "Useful Websites for Learning",
                "Web Dev YouTube Channels",
                "CodePen Ideas",
                "Practise Website Ideas",
                "JavaScript Project Ideas",
            };
        }
        public static List<BoardItem> SampleData()
        {
            return new List<BoardItem>()
            {
                new BoardItem() { BoardId=1,Content="Complete mock-up for client website" },
                new BoardItem() { BoardId=1,Content="Email mock-up to client for feedback" },
                new BoardItem() { BoardId=1,Content="Update personal website header background image" },
                new BoardItem() { BoardId=1,Content="Update personal website heading fonts" },
                new BoardItem() { BoardId=1,Content="Add google map to personal website" },
                new BoardItem() { BoardId=1,Content="Begin draft of CSS Grid article" },
                new BoardItem() { BoardId=1,Content="Read new CSS-Tricks articles" },
                new BoardItem() { BoardId=1,Content="Read new Smashing Magazine articles" },
                new BoardItem() { BoardId=1,Content="Read other bookmarked articles" },
                new BoardItem() { BoardId=1,Content="Look through portfolios to gather inspiration" },
                new BoardItem() { BoardId=1,Content="Create something cool for CodePen" },
                new BoardItem() { BoardId=1,Content="Post latest CodePen work on Twitter" },
                new BoardItem() { BoardId=1,Content="Listen to new Syntax.fm episode" },
                new BoardItem() { BoardId=1,Content="Listen to new CodePen Radio episode" },
                new BoardItem() { BoardId=2,Content="Clear email inbox" },
                new BoardItem() { BoardId=2,Content="Finalise requirements for client web design" },
                new BoardItem() { BoardId=2,Content="Begin work on mock-up for client website" },
                new BoardItem() { BoardId=3,Content="HTML Elements" },
                new BoardItem() { BoardId=3,Content="HTML Form Validation" },
                new BoardItem() { BoardId=3,Content="HTML Structured Data" },
                new BoardItem() { BoardId=3,Content="Advanced CSS Selectors" },
                /*
                new BoardItem() { BoardId=3,Content="CSS Transforms" },
                new BoardItem() { BoardId=3,Content="CSS Animations" },
                new BoardItem() { BoardId=3,Content="CSS Flexbox" },
                new BoardItem() { BoardId=3,Content="CSS Grid" },
                new BoardItem() { BoardId=3,Content="CSS Methodologies (BEM, SMACSS etc.)" },
                new BoardItem() { BoardId=3,Content="SASS/SCSS" },
                new BoardItem() { BoardId=3,Content="Layout Fallbacks" },
                new BoardItem() { BoardId=3,Content="Responsive Design" },
                new BoardItem() { BoardId=3,Content="Design Patterns" },
                new BoardItem() { BoardId=3,Content="JavaScript Fundamentals" },
                new BoardItem() { BoardId=3,Content="JavaScript OOP" },
                new BoardItem() { BoardId=3,Content="JavaScript DOM Manipulation" },
                new BoardItem() { BoardId=3,Content="JavaScript Debugging Techniques" },
                new BoardItem() { BoardId=3,Content="Node Package Manager" },
                new BoardItem() { BoardId=3,Content="Grunt/Gulp" },
                new BoardItem() { BoardId=3,Content="GitHub" },
                new BoardItem() { BoardId=3,Content="Git Commands" },
                new BoardItem() { BoardId=3,Content="Web Accessibility" },
                new BoardItem() { BoardId=3,Content="Web Performance" },
                new BoardItem() { BoardId=3,Content="Web Hosting" },
                new BoardItem() { BoardId=3,Content="Browser Dev Tools" },
                new BoardItem() { BoardId=3,Content="Google Analytics" },
                new BoardItem() { BoardId=3,Content="Basic Photoshop/Sketch Usage" },
                new BoardItem() { BoardId=4,Content="HTML 5.2 New Features" },
                new BoardItem() { BoardId=4,Content="Responsive Images (picture element, srcset/sizes etc.)" },
                new BoardItem() { BoardId=4,Content="Serverless" },
                new BoardItem() { BoardId=4,Content="Variable Fonts" },
                new BoardItem() { BoardId=4,Content="Shadow DOM" },
                new BoardItem() { BoardId=4,Content="ES6+" },
                new BoardItem() { BoardId=4,Content="JSON & AJAX" },
                new BoardItem() { BoardId=4,Content="API's" },
                new BoardItem() { BoardId=4,Content="JavaScript Patterns" },
                new BoardItem() { BoardId=4,Content="JavaScript Testing" },
                new BoardItem() { BoardId=4,Content="jQuery" },
                new BoardItem() { BoardId=4,Content="SVG" },
                new BoardItem() { BoardId=4,Content="React JS" },
                new BoardItem() { BoardId=4,Content="Angular JS" },
                new BoardItem() { BoardId=4,Content="TypeScript" },
                new BoardItem() { BoardId=4,Content="Vue JS" },
                new BoardItem() { BoardId=4,Content="Node JS" },
                new BoardItem() { BoardId=4,Content="Webpack" },
                new BoardItem() { BoardId=4,Content="SEO Techniques" },
                new BoardItem() { BoardId=4,Content="HTML Emails" },
                new BoardItem() { BoardId=4,Content="WordPress" },
                new BoardItem() { BoardId=4,Content="Static Site Generators (Jekyll, Hugo, Gatsby etc.)" },
                new BoardItem() { BoardId=5,Content="Code Academy" },
                new BoardItem() { BoardId=5,Content="CodePen" },
                new BoardItem() { BoardId=5,Content="Codrops" },
                new BoardItem() { BoardId=5,Content="CSS-Tricks" },
                new BoardItem() { BoardId=5,Content="Free Code Camp" },
                new BoardItem() { BoardId=5,Content="Khan Academy" },
                new BoardItem() { BoardId=5,Content="Lynda" },
                new BoardItem() { BoardId=5,Content="Medium" },
                new BoardItem() { BoardId=5,Content="Mozilla Developer Network" },
                new BoardItem() { BoardId=5,Content="Stack Overflow" },
                new BoardItem() { BoardId=5,Content="Team Treehouse" },
                new BoardItem() { BoardId=5,Content="Tuts Plus" },
                new BoardItem() { BoardId=5,Content="Udemy" },
                new BoardItem() { BoardId=5,Content="WPSessions" },
                new BoardItem() { BoardId=5,Content="YouTube" },
                new BoardItem() { BoardId=6,Content="Adam Khoury" },
                new BoardItem() { BoardId=6,Content="Brad Hussey" },
                new BoardItem() { BoardId=6,Content="CSS-Tricks (Chris Coyier)" },
                new BoardItem() { BoardId=6,Content="Derek Banas" },
                new BoardItem() { BoardId=6,Content="DevTips (Travis Neilson)" },
                new BoardItem() { BoardId=6,Content="Free Code Camp" },
                new BoardItem() { BoardId=6,Content="Fun Fun Function (Mattias Petter Johansson)" },
                new BoardItem() { BoardId=6,Content="Google Chrome Developers" },
                new BoardItem() { BoardId=6,Content="Layout Land (Jen Simmons)" },
                new BoardItem() { BoardId=6,Content="Learn Code Academy" },
                new BoardItem() { BoardId=6,Content="Level Up Tuts (Scott Tolinski)" },
                new BoardItem() { BoardId=6,Content="Mackenzie Child" },
                new BoardItem() { BoardId=6,Content="Rachel Andrew" },
                new BoardItem() { BoardId=6,Content="The Net Ninja (Shaun Pelling)" },
                new BoardItem() { BoardId=6,Content="The New Boston (Bucky Roberts)" },
                new BoardItem() { BoardId=6,Content="Traversy Media (Brad Traversy)" },
                new BoardItem() { BoardId=6,Content="Wes Bos" },
                new BoardItem() { BoardId=7,Content="Something cool with CSS Grid" },
                new BoardItem() { BoardId=7,Content="Something cool with CSS Flexbox" },
                new BoardItem() { BoardId=7,Content="Something cool with CSS animations" },
                new BoardItem() { BoardId=7,Content="Something cool with CSS gradients" },
                new BoardItem() { BoardId=7,Content="Something cool with CSS pseudo-elements" },
                new BoardItem() { BoardId=7,Content="Something cool with SVG" },
                new BoardItem() { BoardId=7,Content="Something cool with JavaScript" },
                new BoardItem() { BoardId=7,Content="Something cool with all of the above" },
                new BoardItem() { BoardId=8,Content="Airsoft/Paintballing Centre" },
                new BoardItem() { BoardId=8,Content="Bar/Pub" },
                new BoardItem() { BoardId=8,Content="Bicycle Shop/Repair" },
                new BoardItem() { BoardId=8,Content="Cafe/Coffee Shop" },
                new BoardItem() { BoardId=8,Content="Car Showroom/Garage/Repair/Parts" },
                new BoardItem() { BoardId=8,Content="Construction Company" },
                new BoardItem() { BoardId=8,Content="Fitness/Gym/Leisure Centre" },
                new BoardItem() { BoardId=8,Content="Nightclub" },
                new BoardItem() { BoardId=8,Content="Party Planning Company" },
                new BoardItem() { BoardId=8,Content="PC Build/Repair Service" },
                new BoardItem() { BoardId=8,Content="Portfolio/CV" },
                new BoardItem() { BoardId=8,Content="Real Estate/AirBnB" },
                new BoardItem() { BoardId=8,Content="Restaurant" },
                new BoardItem() { BoardId=8,Content="Skiing/Snowboarding Centre/Company" },
                new BoardItem() { BoardId=8,Content="Streaming Service for Movies/TV" },
                new BoardItem() { BoardId=8,Content="Streaming Service for Video Games" },
                new BoardItem() { BoardId=8,Content="Taxi Service" },
                new BoardItem() { BoardId=8,Content="Travel Agency" },
                new BoardItem() { BoardId=8,Content="Zoo/Safari Park" },
                new BoardItem() { BoardId=9,Content="Analog Clock" },
                new BoardItem() { BoardId=9,Content="Basic Quiz" },
                new BoardItem() { BoardId=9,Content="Bill/Cost Splitter" },
                new BoardItem() { BoardId=9,Content="Countdown Timer" },
                new BoardItem() { BoardId=9,Content="Form Validator" },
                new BoardItem() { BoardId=9,Content="Geolocation (Find places near you etc.)" },
                new BoardItem() { BoardId=9,Content="Gif Search" },
                new BoardItem() { BoardId=9,Content="Note Taking App" },
                new BoardItem() { BoardId=9,Content="Random Name Picker" },
                new BoardItem() { BoardId=9,Content="Secret Message Encoder/Decoder" },
                new BoardItem() { BoardId=9,Content="Sortable Image Gallery" },
                new BoardItem() { BoardId=9,Content="Sortable Table" },
                new BoardItem() { BoardId=9,Content="Tip Calculator" },
                new BoardItem() { BoardId=9,Content="To-Do List" },
                new BoardItem() { BoardId=9,Content="Unit Converter" },
                */
              };
        }
    }
}
