export default (text = "Hello, Webpack!") => {
  const element = document.createElement("h1");

  element.textContent = text;

  return element;
};
