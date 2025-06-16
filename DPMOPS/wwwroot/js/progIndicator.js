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

    const firstDotLabel = document.querySelector('.first-dot-label');
    const secondDotLabel = document.querySelector('.second-dot-label');
    const thirdDotLabel = document.querySelector('.third-dot-label');
    const fourthDotLabel = document.querySelector('.fourth-dot-label');

    const middleText = document.querySelector('.middle-text');

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

            if (firstDot) firstDot.classList.add('hide');
            if (secondDot) secondDot.classList.add('hide');
            if (thirdDot) thirdDot.classList.add('hide');
            if (fourthDot) fourthDot.classList.add('hide');

            if (firstDotLabel) firstDotLabel.classList.add('hide');
            if (secondDotLabel) secondDotLabel.classList.add('hide');
            if (thirdDotLabel) thirdDotLabel.classList.add('hide');
            if (fourthDotLabel) fourthDotLabel.classList.add('hide');

            if (middleText) {
                middleText.classList.remove('hide');
                middleText.innerHTML = '<i class="bi bi-exclamation-triangle-fill"></i>';
                middleText.append(' معلقة');
                middleText.classList.add('text-bg-warning');
            }

            break;
        }
        case 5: {
            progressBar.style.width = '100%';
            progressBar.classList.add('bg-danger');

            if (firstDot) firstDot.classList.add('hide');
            if (secondDot) secondDot.classList.add('hide');
            if (thirdDot) thirdDot.classList.add('hide');
            if (fourthDot) fourthDot.classList.add('hide');

            if (firstDotLabel) firstDotLabel.classList.add('hide');
            if (secondDotLabel) secondDotLabel.classList.add('hide');
            if (thirdDotLabel) thirdDotLabel.classList.add('hide');
            if (fourthDotLabel) fourthDotLabel.classList.add('hide');

            if (middleText) {
                middleText.classList.remove('hide');
                middleText.innerHTML = '<i class="bi bi-x-octagon-fill"></i>';
                middleText.append(' مرفوضة');
                middleText.classList.add('text-bg-danger');
            }

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