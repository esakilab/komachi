let isForward = true;
let animationValue = 0;
const textboxValue = document.getElementById("animationValue");

setInterval(() => {
  const dif = isForward ? 0.1 : -0.1;
  animationValue += dif;
  if (animationValue >= 1) {
    isForward = false;
  } else if (animationValue <= 0) {
    isForward = true;
  }
  document.getElementById("animationValue").value = animationValue;
}, 1000);
