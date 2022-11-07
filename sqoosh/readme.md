SQUOOSH:
		- https://squoosh.app/ - https://github.com/GoogleChromeLabs/squoosh
			- https://github.com/GoogleChromeLabs/squoosh/tree/dev/libsquoosh
			npm -i @squoosh/cli - unknown command
			npx @squoosh/cli --wp2 auto pharmaceutical-students.png
			npx @squoosh/cli --webp auto pharmaceutical-students.png
			npx @squoosh/cli --webp auto Rectangle1789.jpg
			squoosh-cli --webp '{quality: 70}' -d out *
			resize options - https://github.com/GoogleChromeLabs/squoosh/tree/dev/codecs/resize
			https://github.com/GoogleChromeLabs/squoosh/tree/dev/libsquoosh
libSquoosh is an experimental way to run all the codecs you know from the Squoosh web app directly inside your own JavaScript program. libSquoosh uses a worker pool to parallelize processing images. This way you can apply the same codec to many images at once.

libSquoosh is currently not the fastest image compression tool in town and doesn’t aim to be. It is, however, fast enough to compress many images sufficiently quick at once.

Installation:
	libSquoosh can be installed to your local project with the following command:

	$ npm install @squoosh/lib
	You can start using the libSquoosh by adding these lines to the top of your JS program:

	import { ImagePool } from '@squoosh/lib';
	import { cpus } from 'os';
	const imagePool = new ImagePool(cpus().length);
	This will create an image pool with an underlying processing pipeline that you can use to ingest and encode images. The ImagePool constructor takes one argument that defines how many parallel operations it is allowed to run at any given time.

	⚠️ Important! Make sure to only create 1 ImagePool when performing parallel image processing. If you create multiple pools, the ImagePool can run out of memory and crash. By reusing a single ImagePool, you can ensure that the backing worker queue and processing pipeline releases memory prior to processing the next image.

Ingesting images:
	You can ingest a new image like so:

	import fs from 'fs/promises';
	const file = await fs.readFile('./path/to/image.png');
	const image = imagePool.ingestImage(file);
	The ingestImage function can accept any ArrayBuffer whether that is from readFile() or fetch().

	The returned image object is a representation of the original image, that you can now preprocess, encode, and extract information about.

Preprocessing and encoding images:
	When an image has been ingested, you can start preprocessing it and encoding it to other formats. This example will resize the image and then encode it to a .jpg and .jxl image:
	const preprocessOptions = {
	//When both width and height are specified, the image resized to specified size.
	resize: {
		width: 100,
		height: 50,
	},
	/*
	//When either width or height is specified, the image resized to specified size keeping aspect ratio.
	resize: {
		width: 100,
	}
	*/
	};
	await image.preprocess(preprocessOptions);

	const encodeOptions = {
	mozjpeg: {}, //an empty object means 'use default settings'
	jxl: {
		quality: 90,
	},
	};
	const result = await image.encode(encodeOptions);
	The default values for each option can be found in the codecs.ts file under defaultEncoderOptions. Every unspecified value will use the default value specified there. Better documentation is needed here.

	You can run your own code inbetween the different steps, if, for example, you want to change how much the image should be resized based on its original height. (See Extracting image information to learn how to get the image dimensions).

Closing the ImagePool
	When you have encoded everything you need, it is recommended to close the processing pipeline in the ImagePool. This will not delete the images you have already encoded, but it will prevent you from ingesting and encoding new images.

	Close the ImagePool pipeline with this line:

	await imagePool.close();