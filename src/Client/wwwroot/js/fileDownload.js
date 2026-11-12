// Lets the browser save text produced by the app as a file.
export function downloadText(fileName, text, contentType) {
    const url = URL.createObjectURL(new Blob([text], { type: contentType }));
    const link = document.createElement('a');
    link.href = url;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    link.remove();
    // Give the browser time to start the download before the data is released.
    setTimeout(() => URL.revokeObjectURL(url), 1000);
}
