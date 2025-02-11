window.preventDragDefault = (e) => {
    e.preventDefault();
    e.stopPropagation();  // Optionally stop further propagation of the event
};
