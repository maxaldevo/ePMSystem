import ImageViewer from 'ImageViewer';

Array.from(document.querySelectorAll('.pannable-image')).forEach((elem) => {
  new ImageViewer(elem);
});
