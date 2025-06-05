function checkProgressBarWidth() {
    const progressBar = document.querySelector('.progress-bar');
    if (!progressBar) return;

    // Get the width percentage as a number
    const widthStyle = progressBar.style.width;
    const widthValue = parseInt(widthStyle);

    const firstDot = document.querySelector('.first-dot');
    const secondDot = document.querySelector('.second-dot');
    const thirdDot = document.querySelector('.third-dot');
    const fourthDot = document.querySelector('.fourth-dot');

    switch (widthValue) {
        case 1: {
            progressBar.style.width = '0%';

            if (firstDot) {
                firstDot.style.backgroundColor = 'var(--current-dot-color)';
            }
            break;
        }
        case 2: {
            progressBar.style.width = '33%';

            if (firstDot) {
                firstDot.style.backgroundColor = 'var(--default-dot-color)';
            }
            if (secondDot) {
                secondDot.style.backgroundColor = 'var(--current-dot-color)';
            }
            break;
        }
        case 3: {
            progressBar.style.width = '66%';

            if (firstDot) {
                firstDot.style.backgroundColor = 'var(--default-dot-color)';
            }
            if (secondDot) {
                secondDot.style.backgroundColor = 'var(--default-dot-color)';
            }
            if (thirdDot) {
                thirdDot.style.backgroundColor = 'var(--current-dot-color)';
            }
            break;
        }
        case 4: {
            progressBar.style.width = '100%';
            progressBar.classList.add('bg-warning');

            if (firstDot) firstDot.style.backgroundColor = 'var(--warning-dot-color)';
            if (secondDot) secondDot.style.backgroundColor = 'var(--warning-dot-color)';
            if (thirdDot) thirdDot.style.backgroundColor = 'var(--warning-dot-color)';
            if (fourthDot) fourthDot.style.backgroundColor = 'var(--warning-dot-color)';
            break;
        }
        case 5: {
            progressBar.style.width = '100%';
            progressBar.classList.add('bg-danger');

            if (firstDot) firstDot.style.backgroundColor = 'var(--danger-dot-color)';
            if (secondDot) secondDot.style.backgroundColor = 'var(--danger-dot-color)';
            if (thirdDot) thirdDot.style.backgroundColor = 'var(--danger-dot-color)';
            if (fourthDot) fourthDot.style.backgroundColor = 'var(--danger-dot-color)';
            break;
        }
        case 6: {
            progressBar.style.width = '100%';

            if (firstDot) firstDot.style.backgroundColor = 'var(--success-dot-color)';
            if (secondDot) secondDot.style.backgroundColor = 'var(--success-dot-color)';
            if (thirdDot) thirdDot.style.backgroundColor = 'var(--success-dot-color)';
            if (fourthDot) fourthDot.style.backgroundColor = 'var(--success-dot-color)';

            progressBar.classList.add('bg-success');
            break;
        }
        default:
            // handle unexpected values
            break;
    }
}

// Run when the DOM is fully loaded
document.addEventListener('DOMContentLoaded', checkProgressBarWidth);