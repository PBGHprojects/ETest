$('.dropdown-change-alert').change(() => {
    const target = $(event.target);
    const options = target
        .find('option')
        .get()
        .reduce((x, y) => ({ ...x, [y.value]: y.text }), {});

    const prevState = target
        .data('prevstate')
        || [];
    const state = target
        .val();

    // deselected
    prevState
        .filter(s => !state.includes(s))
        .forEach(s => toastr.warning(options[s]));

    // selected
    state
        .filter(s => !prevState.includes(s))
        .forEach(s => toastr.info(options[s]));

    target.data('prevstate', state);
});