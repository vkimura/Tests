console.log("Interesting");

//Create heading
const heading = document.createElement("h1");
heading.textContent = "Webpack 5 based on Tania Rascia's tutorial.";

//Appending heading node to the DOM
const root = document.querySelector("#root");
root.appendChild(heading);
