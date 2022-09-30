alert('Hello Webpack Project.');

// import fs from 'fs/promises';
import { ImagePool } from '@squoosh/lib';
// import { cpus } from 'os';
// const imagePool = new ImagePool(cpus().length);
const imagePool = new ImagePool();
//https://web.dev/introducing-libsquoosh/
//https://github.com/GoogleChromeLabs/squoosh/tree/dev/libsquoosh
//https://www.npmjs.com/package/@squoosh/lib


// Accepts both file paths and Buffers/TypedArrays.
const image = imagePool.ingestImage("./pharmaceutical-students.png");

// Optional.
await image.preprocess({
    resize: {
        enabled: true,
        width: 300,
    },
});

await image.encode({
    // All codecs are initialized with default values
    // that can be individually overwritten.
    // webp: {
    //     quality: 70,
    // }
    mozjpeg: {
        quality: 10,
    },
    // avif: {
    //     cqLevel: 10,
    // },
    // jxl: {},
});

// const { extension, binary } = await image.encodedWith.mozjpeg;
// const { extension, binary } = await image.encodedWith.webp;
// await fs.writeFile(`output.${extension}`, binary);

await imagePool.close();

