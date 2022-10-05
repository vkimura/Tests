import vcadlogo from './images/vcad-logo.svg';
import nursephoto from './images/nurses-congregating-around-desk-378-264.png';
import './styles/index.scss';

console.log("Interesting");

// class property without constructor to test babel-loader
class Game {
    name = "Violin Charades";
}
const myGame = new Game();
const p = document.createElement('p');
p.textContent = `I like ${myGame.name}`;

// add the p element to class js-output
const output = document.querySelector('.js-output');
output.appendChild(p);

//Create heading
const heading = document.createElement("h1");
heading.textContent = "Webpack 5 based on Tania Rascia's tutorial. Update 2022-10-05-356PM.";

//Appending heading node to the DOM
const root = document.querySelector("#root");
root.appendChild(heading);
